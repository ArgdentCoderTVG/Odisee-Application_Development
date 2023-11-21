using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace User_Registration_App.Models
{
    public class UserBindingModel
    {
        [Required(ErrorMessage = "Voornaam is verplicht!")]
        [Display(Name = "Voornaam")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Familienaam is verplicht!")]
        [Display(Name = "Familienaam")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Geboortedatum is verplicht!")]
        [Display(Name = "Geboortedatum")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Geslacht is verplicht!")]
        [Display(Name = "Geslacht")]
        public Gender? Gender { get; set; }

        [Required(ErrorMessage = "Email is verplicht!")]
        [EmailAddress(ErrorMessage = "Dit is geen geldig email-adres!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Wachtwoord is verplicht!")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Wachtwoord moet min. 8 en max. 100 karakters lang zijn!")]
        public string Password { get; set; }

        [Display(Name = "Schrijf me in voor de niewsbrief")]
        public bool Newsletter { get; set; }

        public IEnumerable<SelectListItem> Languages { get; set; } = new List<SelectListItem>()
        {
            new SelectListItem(){ Text="Nederlands",  Value="NL"},
            new SelectListItem(){ Text="Frans",  Value="FR"},
            new SelectListItem(){ Text="Engels",  Value="EN"},
        };

        [Required(ErrorMessage = "Taal is verplicht!")]
        [Display(Name = "Taal")]
        public string SelectedLanguage { get; set; }

    }

    public enum Gender
    {
        MALE, FEMALE, OTHER
    }
}