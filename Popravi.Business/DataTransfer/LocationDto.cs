using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Popravi.Business.DataTransfer
{
    public class LocationDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Naziv lokacije je obavezan.")]
        [RegularExpression(@"^[A-Z][a-z]{2,20}(\s[A-Z][a-z]{2,20})*$", ErrorMessage = "Naziv nije u dobrom formatu. Primer - Palilula")]
        public string Name { get; set; }

        public string CityName { get; set; }
    }
}
