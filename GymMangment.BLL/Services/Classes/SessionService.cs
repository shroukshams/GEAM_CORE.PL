using GymManagmemnt.BLL.ViewModels.SessionViewModel;
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
        public SessionService(IUnitOfWork unitOfWork) {

            _unitOfWork = unitOfWork;
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
