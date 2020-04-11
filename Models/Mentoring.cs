using System;
using System.Collections.Generic;

namespace ExpertCompetence.Models
{
    public partial class Mentoring
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ExpertId { get; set; }

        public virtual Expert Expert { get; set; }
        public virtual User User { get; set; }
    }
}
