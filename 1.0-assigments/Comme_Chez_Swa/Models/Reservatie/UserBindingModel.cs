using Comme_Chez_Swa.Models.Reservatie.Utility;
using System.ComponentModel.DataAnnotations;

namespace Comme_Chez_Swa.Models.Reservatie
{
    public class UserBindingModel
    {
        [Required(ErrorMessage = "Voornaam is verplicht!")]
        [Display(Name = "Voornaam")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Familienaam is verplicht!")]
        [Display(Name = "Familienaam")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is verplicht")]
        [EmailAddress(ErrorMessage = "Dit is geen geldig email-adres!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Email bevestiging is verplicht")]
        [EmailAddress(ErrorMessage = "Dit is geen geldig email-adres!")]
        [EmailConfirmation("Email", ErrorMessage = "Email en bevestiging komen niet overeen")]
        public string EmailConfirm { get; set; }
    }
}