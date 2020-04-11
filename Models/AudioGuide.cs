using System;
using System.Collections.Generic;

namespace ExpertCompetence.Models
{
    public partial class AudioGuide
    {
        public AudioGuide()
        {
            AudioGuideRate = new HashSet<AudioGuideRate>();
            CompetenceAudioGuide = new HashSet<CompetenceAudioGuide>();
            Meditation = new HashSet<Meditation>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? ExpertId { get; set; }

        public virtual Expert Expert { get; set; }
        public virtual ICollection<AudioGuideRate> AudioGuideRate { get; set; }
        public virtual ICollection<CompetenceAudioGuide> CompetenceAudioGuide { get; set; }
        public virtual ICollection<Meditation> Meditation { get; set; }
    }
}
