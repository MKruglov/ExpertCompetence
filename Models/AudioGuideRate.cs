using System;
using System.Collections.Generic;

namespace ExpertCompetence.Models
{
    public partial class AudioGuideRate
    {
        public int Id { get; set; }
        public int? AudioGuideId { get; set; }
        public int? UserId { get; set; }

        public virtual AudioGuide AudioGuide { get; set; }
        public virtual User User { get; set; }
    }
}
