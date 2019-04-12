using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Popravi.Business.DataTransfer
{
    public class MalfunctionDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Naziv kvara je obavezan.")]
        [RegularExpression(@"^[A-Z][a-z]{2,20}(\s[a-z][a-z]{2,20})*$", ErrorMessage = "Naziv nije u dobrom formatu. Primer - Bojler")]
        public string Name { get; set; }
    }
}
