using Comme_Chez_Swa.Models.Home;

namespace Comme_Chez_Swa.Models.Home.Reservations
{
    // [NOTE] POCO with data integrity focus, solely instanced/manipulated using constructor (instance state is always intial state)
    public class ReservationsViewModel : BaseViewModel
    {
        public Reservations Reservations { get; }

        // [NOTE] One entry point for altering the object state
        public ReservationsViewModel(Reservations reservations)
        {
            Reservations = reservations;
        }
    }
}
