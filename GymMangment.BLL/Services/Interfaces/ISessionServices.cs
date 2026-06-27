using GymMangment.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymMangment.BLL.Services.Interfaces
{
    public interface ISessionServices
    {
        Task<IEnumerable<Session>> GetSessionsAsync(CancellationToken ct = default);
    }
}
