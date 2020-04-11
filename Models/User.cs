using System;
using System.Collections.Generic;

namespace ExpertCompetence.Models
{
    public partial class User
    {
        public User()
        {
            AudioGuideRate = new HashSet<AudioGuideRate>();
            Meditation = new HashSet<Meditation>();
            Mentoring = new HashSet<Mentoring>();
            UserFeature = new HashSet<UserFeature>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public byte[] CreatedAt { get; set; }
        public string MeditationAim { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<AudioGuideRate> AudioGuideRate { get; set; }
        public virtual ICollection<Meditation> Meditation { get; set; }
        public virtual ICollection<Mentoring> Mentoring { get; set; }
        public virtual ICollection<UserFeature> UserFeature { get; set; }
    }
}
