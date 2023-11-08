using Comme_Chez_Swa.Models.Reservatie.Utility;
using System.ComponentModel.DataAnnotations;

namespace Comme_Chez_Swa.Models.Reservatie
{
    public class ReservatieBindingModel
    {
        [Required(ErrorMessage = "Voornaam is verplicht!")]
        [Display(Name = "Voornaam")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Familienaam is verplicht!")]
        [Display(Name = "Familienaam")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is verplicht!")]
        [Display(Name = "Email-adres")]
        [EmailAddress(ErrorMessage = "Dit is geen geldig email-adres!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Email bevestiging is verplicht!")]
        [EmailAddress(ErrorMessage = "Dit is geen geldig email-adres!")]
        [EmailConfirmation("Email", ErrorMessage = "Email en bevestiging komen niet overeen!")]
        [Display(Name = "Email-adres bevestiging")]
        public string EmailConfirm { get; set; }

        [Required(ErrorMessage = "Reservatie tijdsstip is verplicht!")]
        [Display(Name = "Reservatie tijdsstip")]
        public EnumReservationTime ReservationTime { get; set; }

        [Required(ErrorMessage = "Aantal personen is verplicht!")]
        [Display(Name = "Aantal personen")]
        public byte PartySize { get; set; }

        [Required(ErrorMessage = "Akkoord met algemene voorwaarden is verplicht!")]
        [ExpectedValue(true, ErrorMessage = "U moet akkoord gaan met de algemene voorwaarden.")]
        [Display(Name = "Algemene voorwaarden akkoord")]
        public bool AgreedToTermsOfService { get; set; }
    }
}