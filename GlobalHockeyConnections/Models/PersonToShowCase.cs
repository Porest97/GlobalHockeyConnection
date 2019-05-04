using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalHockeyConnections.Models
{
    public class PersonToShowCase
    {
        public int ID { get; set; }

        public ShowCase ShowCase { get; set; }
        public int? ShowcaseId { get; set; }


        public Person Person { get; set; }
        public int? PersonId { get; set; }
    }
}
