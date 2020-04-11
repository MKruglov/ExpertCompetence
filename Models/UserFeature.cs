using System;
using System.Collections.Generic;

namespace ExpertCompetence.Models
{
    public partial class UserFeature
    {
        public int Id { get; set; }
        public int? CompetenceId { get; set; }
        public int? UserId { get; set; }

        public virtual Competence Competence { get; set; }
        public virtual User User { get; set; }
    }
}
