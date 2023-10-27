using System.Collections.Immutable;

namespace Comme_Chez_Swa.Models.Home.Reservations
{
    // [NOTE] POCO with data integrity focus, solely instanced/manipulated using constructor (instance state is always intial state)
    public class Reservations
    {
        // [NOTE] Collections are fixed-size, immutable and simple -> ImmutableArray<Type>
        public ImmutableArray<Reservation> ReservationsAll { get; }
        public ImmutableArray<Reservation> ReservationsToday
        {
            get
            {
                return ReservationsAll
                    .Where(reservation => reservation.ReservationTime.Date == DateTime.Now.Date)
                    .ToImmutableArray();
            }
        }

        // [NOTE] One entry point for altering the object state
        public Reservations(ImmutableArray<Reservation> reservationsAll)
        {
            ReservationsAll = reservationsAll;
        }
    }
}
