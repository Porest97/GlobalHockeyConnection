using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalHockeyConnections.Models
{
    public class ShowCase
    {
        public int Id { get; set; }


        public string SwocaseName { get; set; }

        public Location Location { get; set; }
        public int? LocationId { get; set; }



    }
}
