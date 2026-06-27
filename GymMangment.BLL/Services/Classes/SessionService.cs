using AutoMapper;
using GymManagment.BLL.ViewModels.SessionViewModel;
using GymMangement.DAL.Models.Enums;
using GymMangment.BLL.Services.Interfaces;
using GymMangment.DAL.Models;
using GymMangment.DAL.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;

namespace GymMangment.BLL.Services.Classes
{
    public class SessionService : ISessionServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SessionService(IUnitOfWork unitOfWork,IMapper mapper) {

            _unitOfWork = unitOfWork;
                _mapper = mapper;
        }

        public async Task<bool> CreateSessionAsync(CreateSessionViewModel model, CancellationToken ct = default)
        {
            if (model.EndDate <= model.StartDate) return false;
            if (model.StartDate <= DateTime.Now) return false;
            if (model.Capacity < 1 || model.Capacity > 25) return false;
            var tranier = await _unitOfWork.GetRepository<Trainer>().GetByIdAsync(model.TrainerId);
            if (tranier == null) return false;
            var Category = await _unitOfWork.GetRepository<Category>().GetByIdAsync(model.CategoryId);
            if (Category == null) return false;
            var isValid = Enum.TryParse<specialty>(Category.Name, true, out var CategorySpeciallty);
            if (!isValid||tranier.specialty!=CategorySpeciallty) return false;
            var session= _mapper.Map<Session>(model);
            
        }

        public async Task<IEnumerable<Session>> GetSessionsAsync(CancellationToken ct = default)
        {
            var sessions = await _unitOfWork.SessionRepository.GetSessionsWithTrainerAndCategory(ct);
            if (sessions == null || !sessions.Any()) return null;
            var mappedSessions = sessions.Select(S => new SessionViewModel()
            {
                Id = S.ID,
                Capacity = S.Capacity,
                CategoryName=S.Category.Name,
                TrainerName=S.Trainer.Name,
                StartDate = S.StartDate,
                EndDate = S.EndDate,
                Description = S.Description,
             


            });
            foreach (var session in mappedSessions)
            {
                session.AvailableSlots = session.Capacity - await _unitOfWork.SessionRepository.CountOfBookedSlotsAsync(session.Id, ct);


            }
            return (IEnumerable<Session>)mappedSessions;
}
}
}
