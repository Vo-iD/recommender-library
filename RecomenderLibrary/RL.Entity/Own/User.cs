using System;
using System.Collections.Generic;

namespace RL.Entity.Own
{
    public class User : SafeRemoveAggregation
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime RegisterDate { get; set; }

        public DateTime LastLoginDate { get; set; }

        public IEnumerable<Message> ReceivedMessages { get; set; }

        public IEnumerable<Message> SendedMessages { get; set; }

        public IEnumerable<QuestionnaireItem> Items { get; set; }
    }
}
