using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL.Entity.Own
{
    public class QuestionnaireAnswer : SafeRemoveAggregation
    {
        public QuestionnaireItem Question { get; set; }

        public string Answer { get; set; }
    }
}
