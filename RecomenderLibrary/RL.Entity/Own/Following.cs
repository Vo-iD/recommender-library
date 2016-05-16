using System;

namespace RL.Entity.Own
{
    public class Following : SafeRemoveAggregation
    {
        public User Follower { get; set; }

        public User Followed { get; set; }

        public DateTime StartDate { get; set; }
    }
}
