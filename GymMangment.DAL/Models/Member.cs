using System;
using System.Collections.Generic;
using System.Text;

namespace GymMangment.DAL.Models
{
    public class Member : GymUser
    {
        public string? photo { get; set; }

        //JionDate ==createdAt
        #region Relationships
        public HealthRecord HealthRecord { get; set; } = default!;
        #endregion
    }
}
