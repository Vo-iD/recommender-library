using System;
using System.Collections.Generic;

namespace RL.Entity.Own
{
    public class Questionnaire : SafeRemoveAggregation
    {
        public DateTime Created { get; set; }

        public string Notes { get; set; }

        public virtual ICollection<QuestionnaireItem> Items { get; set; }

        public virtual ICollection<QuestionnaireHistory> History { get; set; }
    }
}
