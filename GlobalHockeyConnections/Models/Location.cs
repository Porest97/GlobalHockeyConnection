using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalHockeyConnections.Models
{
    public class Location
    {
        public int Id { get; set; }

        [Display(Name = "Namn")]
        public string LocationName { get; set; }

        [Display(Name = "Gatuadress")]
        public string LocationStreetAddress { get; set; }

        [Display(Name = "Post Nr")]
        [DataType(DataType.PostalCode)]
        public string LocationZipCode { get; set; }

        [Display(Name = "Post Ort")]
        public string LocationCounty { get; set; }

        [Display(Name = "Land")]
        public string LocationCountry { get; set; }

        [Display(Name = "Adress")]
        public string LocationAddress { get { return string.Format("{0} {1} {2}", LocationStreetAddress, LocationZipCode, LocationCounty); } }

        public string LocationString { get { return string.Format("{0} {1} {2}", LocationName, LocationCounty, LocationCountry); } }
    }
}
