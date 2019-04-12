using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Popravi.Mvc.Models
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Sifra je obavezna.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$", ErrorMessage = "Sifra nije u dobrom formatu. Primer- sifra1")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Sifra je obavezna.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$", ErrorMessage = "Sifra nije u dobrom formatu. Primer- sifra1")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Sifra je obavezna.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$", ErrorMessage = "Sifra nije u dobrom formatu. Primer- sifra1")]
        public string NewPasswordConfirm { get; set; }
    }
}
