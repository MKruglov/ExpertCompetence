using System;
using System.Collections.Generic;

namespace ExpertCompetence.Models
{
    public partial class CompetenceAudioGuide
    {
        public int Id { get; set; }
        public int? AudioGuideId { get; set; }
        public int? CompetenceId { get; set; }

        public virtual AudioGuide AudioGuide { get; set; }
        public virtual Competence Competence { get; set; }
    }
}
