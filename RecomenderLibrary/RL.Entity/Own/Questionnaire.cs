using System;
using System.Collections.Generic;

namespace RL.Entity.Own
{
    public class Questionnaire : SafeRemoveAggregation
    {
        public DateTime Created { get; set; }

        public string Notes { get; set; }

        public IEnumerable<QuestionnaireItem> Items { get; set; }

        public IEnumerable<QuestionnaireHistory> History { get; set; }
    }
}
