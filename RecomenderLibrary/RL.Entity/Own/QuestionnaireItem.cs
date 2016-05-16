using System.Collections.Generic;

namespace RL.Entity.Own
{
    public class QuestionnaireItem : SafeRemoveAggregation
    {
        public Questionnaire Questionnaire { get; set; }

        public string Question { get; set; }

        public IEnumerable<QuestionnaireAnswer> Answers { get; set; }
    }
}
