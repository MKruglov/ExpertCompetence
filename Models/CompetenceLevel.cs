using System;
using System.Collections.Generic;

namespace ExpertCompetence.Models
{
    public partial class CompetenceLevel
    {
        public int Id { get; set; }
        public int? CompetenceId { get; set; }
        public int? ExpertId { get; set; }
        public int? Level { get; set; }

        public virtual Competence Competence { get; set; }
        public virtual Expert IdNavigation { get; set; }
    }
}
