using System;
using System.Collections.Generic;
using System.Text;

namespace GymMangment.DAL.Models
{
    public class Plan: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int DurationOnDays { get; set; }
        public bool IsActive { get; set; }
        #region Relationships
        public ICollection<MemberShip> MemberShips { get; set; }
        #endregion

    }
}
