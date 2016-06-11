using System;
using System.Collections.Generic;

namespace RL.RemoteData.Contract.RemoteModels
{
    public class BookDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public IEnumerable<string> Authors { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public ImageLinksDto Image { get; set; }
        public DateTime PublishDate { get; set; }
        public int? Mark { get; set; }
    }
}
