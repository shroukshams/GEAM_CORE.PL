using GymMangement.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymMangment.DAL.Models
{
    public class Trainer : BaseEntity
    {
        //hireDate == createdAt
        public string Name { get; set; }
        public specialty? specialty { get; set; }
        #region Relationships
        public ICollection<Session> sessions { get; set; } = default!;
        #endregion
    }
}

