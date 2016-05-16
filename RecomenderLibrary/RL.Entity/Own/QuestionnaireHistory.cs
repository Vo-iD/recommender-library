using System;

namespace RL.Entity.Own
{
    public class QuestionnaireHistory : SafeRemoveAggregation
    {
        public User Respondent { get; set; }

        public Questionnaire Questionnaire { get; set; }

        public DateTime PassDate { get; set; }
    }
}
