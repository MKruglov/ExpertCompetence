using System;
using System.Collections.Generic;

namespace ExpertCompetence.Models
{
    public partial class Meditation
    {
        public Meditation()
        {
            Review = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public byte[] CreatedAt { get; set; }
        public int? NeuralNetworkScore { get; set; }
        public int? PhysiologyScore { get; set; }
        public int? WearbleDiviceScore { get; set; }
        public int? UserId { get; set; }
        public int? AudioGuideId { get; set; }

        public virtual AudioGuide AudioGuide { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Review> Review { get; set; }
    }
}
