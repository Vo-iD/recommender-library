using System;

namespace RL.Entity.Own
{
    public class Message : SafeRemoveAggregation
    {
        public User Sender { get; set; }

        public User Receiver { get; set; }

        public string Body { get; set; }

        public DateTime Date { get; set; }
    }
}
