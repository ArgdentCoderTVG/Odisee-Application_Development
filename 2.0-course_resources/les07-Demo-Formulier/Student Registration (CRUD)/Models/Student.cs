using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Registration.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Voornaam is een verplicht veld!")]
        [Display(Name = "Voornaam")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Familienaam is een verplicht veld!")]
        [Display(Name = "Familienaam")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Geboortedatum is een verplicht veld")]
        [Display(Name = "Geboortedatum")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Email is een verplicht veld!")]
        [EmailAddress(ErrorMessage = "Dit is geen geldig email-adres!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Gelieve een geslacht te selecteren!")]
        [Display(Name = "Geslacht")]
        public Gender? Gender { get; set; }

    }

    public enum Gender { Male, Female, Other}
}
