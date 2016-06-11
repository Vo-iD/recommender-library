using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RL.Web.Models
{
    [DataContract]
    public class FavoriteBookModel
    {
        [DataMember(Name = "bookId")]
        public string BookId { get; set; }
        [DataMember(Name = "mark")]
        public int Mark { get; set; }
    }
}