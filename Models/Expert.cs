using System;
using System.Collections.Generic;

namespace ExpertCompetence.Models
{
    public partial class Expert
    {
        public Expert()
        {
            AudioGuide = new HashSet<AudioGuide>();
            Mentoring = new HashSet<Mentoring>();
            Review = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }

        public virtual CompetenceLevel CompetenceLevel { get; set; }
        public virtual ICollection<AudioGuide> AudioGuide { get; set; }
        public virtual ICollection<Mentoring> Mentoring { get; set; }
        public virtual ICollection<Review> Review { get; set; }
    }
}
