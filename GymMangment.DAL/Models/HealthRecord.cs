using System;
using System.Collections.Generic;
using System.Text;

namespace GymMangment.DAL.Models
{
    public class HealthRecord : BaseEntity
    {
        public decimal heigh { get; set; }
        public decimal weight { get; set; }
        public string bloodType { get; set; } = default!;
        public string? Note { get; set; }
        //update at of baseEntity will be the last update of health record

        #region Relationships
        public Member Member { get; set; } = default!;
        public int MemberId { get; set; }
        #endregion
    }
}
