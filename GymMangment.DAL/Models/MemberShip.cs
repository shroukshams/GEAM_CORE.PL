using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text;

namespace GymMangment.DAL.Models
{
        public class MemberShip : BaseEntity
    {
        public Member Member { get; set; }
        public Plan Plan { get; set; }
        public int MemberId { get; set; }
        public int PlanId { get; set; }
        public DateTime EndtDate { get; set; }

        [NotMapped]

        public string status => EndtDate > DateTime.Now ? "Active" : "Expired";
        public bool IsActive => EndtDate > DateTime.Now;
    }
}
