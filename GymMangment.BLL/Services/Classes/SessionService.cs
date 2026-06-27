using AutoMapper;
using GymManagement.BLL.Common;
using GymManagement.BLL.Services.Interfaces;
using GymManagement.DAL.Repositories.Interfaces;
using GymManagmemnt.BLL.ViewModels.SessionViewModel;
using GymManagment.BLL.ViewModels.SessionViewModel;
using GymMangement.DAL.Models.Enums;
using GymMangment.BLL.Services.Interfaces;
using GymMangment.DAL.Models;
using GymMangment.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using static GymMangment.BLL.Services.Classes.SessionService;

namespace GymMangment.BLL.Services.Classes
{


    public class SessionService : ISessionServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SessionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<IEnumerable<SessionViewModel>> GetAllSessionsAsync(CancellationToken ct)
        {
            // use eager loading
            var sessions = await _unitOfWork.SessionRepository.GetSessionsWithTrainerAndCategory(ct);


            if (sessions == null || !sessions.Any()) return null;
            var mappedSession = sessions.Select(S => new SessionViewModel()
            {
                Id = S.ID,
                Capacity = S.Capacity,
                CategoryName = S.Category.Name,
                TrainerName = S.Trainer.Name,
                StartDate = S.StartDate,
                EndDate = S.EndDate,
                Description = S.Description,
            });

            // booking slots
            foreach (var session in mappedSession)
            {
                session.AvailableSlots = session.Capacity - await _unitOfWork.CountOfBookedSlotsAsync(session.Id, ct);

            }
            return mappedSession;
        }
        public async Task<Result> CreateSessionAsync(CreateSessionViewModel model, CancellationToken ct = default)
        {
            // validations
            if (model.EndDate <= model.StartDate) return Result.Validation("End date must be greater than start date.");
            if (model.StartDate <= DateTime.Now) return Result.Validation("Start date has to be in future");
            if (model.Capacity < 1 || model.Capacity > 25) return Result.Validation("Capacity must be between 1 and 25");

            // get trainer
            var trainer = await _unitOfWork.GetRepository<Trainer>().GetByIdAsync(model.TrainerId);
            if (trainer == null) return Result.NotFound("Trainer not found");

            // get category
            var category = await _unitOfWork.GetRepository<Category>().GetByIdAsync(model.CategoryId);
            if (category == null) return Result.NotFound("Category not found");

            // check if trainer speciality == category specialty
            bool isValid = Enum.TryParse<specialty>(category.Name, true, out var categorySpecialty);
            if (!isValid || trainer.specialty != categorySpecialty) return Result.Validation("Trainer and category must have the same specialty");

            // createsessionmodel => session
            var session = _mapper.Map<Session>(model);

            _unitOfWork.GetRepository<Session>().AddAsync(session);
            var result = await _unitOfWork.SaveChangesAsync();
            return result > 0 ? Result.Ok() : Result.Fail("Failed to create session");

        }

        public async Task<IEnumerable<TrainerSelectViewModel>> GetTrainerForDropDown(CancellationToken ct = default)
        {
            var result = await _unitOfWork.GetRepository<Trainer>().GetAllAsync(ct: ct);
            return _mapper.Map<IEnumerable<TrainerSelectViewModel>>(result);
        }

        public async Task<IEnumerable<CategorySelectViewModel>> GetCategoryForDropDown(CancellationToken ct = default)
        {
            var result = await _unitOfWork.GetRepository<Category>().GetAllAsync(ct: ct);
            return _mapper.Map<IEnumerable<CategorySelectViewModel>>(result);

        }
    }
}