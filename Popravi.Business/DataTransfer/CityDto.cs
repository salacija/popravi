using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Popravi.Business.DataTransfer
{
    public class CityDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Naziv grada je obavezan.")]
        [RegularExpression(@"^[A-Z][a-z]{2,20}(\s[A-Z][a-z]{2,20})*$", ErrorMessage = "Naziv nije u dobrom formatu. Primer - Beograd")]
        public string Name { get; set; }

        //[Required(ErrorMessage ="Postanski kod je neophodan.")]
        //[RegularExpression("[0-9]{5}", ErrorMessage ="Postanski broj nije u dobrom formatu.")]
        public string ZipCode { get; set; }
    }
}
