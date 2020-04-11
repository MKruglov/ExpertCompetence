using System;
using System.Collections.Generic;

namespace ExpertCompetence.Models
{
    public partial class Competence
    {
        public Competence()
        {
            CompetenceAudioGuide = new HashSet<CompetenceAudioGuide>();
            CompetenceLevel = new HashSet<CompetenceLevel>();
            UserFeature = new HashSet<UserFeature>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public int? AudioGuideId { get; set; }
        public int? UserId { get; set; }

        public virtual ICollection<CompetenceAudioGuide> CompetenceAudioGuide { get; set; }
        public virtual ICollection<CompetenceLevel> CompetenceLevel { get; set; }
        public virtual ICollection<UserFeature> UserFeature { get; set; }
    }
}
