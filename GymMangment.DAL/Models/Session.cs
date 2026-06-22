using System;
using System.Collections.Generic;
using System.Text;

namespace GymMangment.DAL.Models
{
    public class Session : BaseEntity
    {
        public string Description { get; set; } = default!;
        public int Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        #region Relationships
        public Trainer trainer { get; set; } = default!;
        public int TrainerId { get; set; }
        public Category category { get; set; } = default!;
        public int CategoryId { get; set; }
        public ICollection<Booking> SessionMember { get; set; } = default!;
        #endregion
    }
}

