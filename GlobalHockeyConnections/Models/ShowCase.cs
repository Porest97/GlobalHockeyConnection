using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalHockeyConnections.Models
{
    public class ShowCase
    {
        public int Id { get; set; }

        [Display(Name = "Event")]
        public string SwocaseName { get; set; }

        [Display(Name = "Location")]
        public Location Location { get; set; }
        public int? LocationId { get; set; }

        [Display(Name = "Information")]
        public ShowCaseDescription ShowCaseDescription { get; set; }
        public int? ShowCaseDescriptionId { get; set; }

        [Display(Name = "Event Direktor")]
        public Person Person { get; set; }
        public int? PersonId { get; set; }


    }
}
