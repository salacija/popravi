using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Popravi.Business.DataTransfer.User
{
   public class RegisterUserDto
    {
        [Required(ErrorMessage = "Ime je obavezno.")]
        [RegularExpression(@"^[A-Z][a-z]{2,10}(\s[A-Z][a-z]{2,10})*$", ErrorMessage = "Ime nije u dobrom formatu. Primer - Pera")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Prezime je obavezno.")]
        [RegularExpression(@"^[A-Z][a-z]{2,12}(\s[A-Z][a-z]{2,12})*$", ErrorMessage = "Prezime nije u dobrom formatu. Primer - Peric")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "E-mail adresa je obavezna.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Korisnicko ime je obavezno.")]
        [RegularExpression("^(?=.{3,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$", ErrorMessage = "Korisnicko ime nije u dobrom formatu. Primer - pera")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Sifra je obavezna.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$", ErrorMessage = "Sifra nije u dobrom formatu. Primer- sifra1")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Sifre se ne poklapaju.")]
        public string PasswordConfirm { get; set; }

        public string Uuid { get; set; }
    }
}
