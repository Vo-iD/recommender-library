using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RL.Entity.Own
{
    public class FavoriteBook : OwnEntityAggregation
    {
        public string BookId { get; set; }
        public int Mark { get; set; }
        public User User { get; set; }
    }
}
