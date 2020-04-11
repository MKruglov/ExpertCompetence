using System;
using System.Collections.Generic;

namespace ExpertCompetence.Models
{
    public partial class Review
    {
        public int Id { get; set; }
        public string ReviewText { get; set; }
        public int? Score { get; set; }
        public int? MeditationId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? ExpertId { get; set; }

        public virtual Expert Expert { get; set; }
        public virtual Meditation Meditation { get; set; }
    }
}
