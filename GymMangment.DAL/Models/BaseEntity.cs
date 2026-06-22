using System;
using System.Collections.Generic;
using System.Text;

namespace GymMangment.DAL.Models
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
