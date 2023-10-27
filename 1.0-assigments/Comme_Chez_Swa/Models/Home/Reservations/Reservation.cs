namespace Comme_Chez_Swa.Models.Home.Reservations
{
    // [NOTE] POCO with data integrity focus, solely instanced/manipulated using constructor (instance state is always intial state)
    public class Reservation
    {
        // [NOTE] Some properties are non-essential -> nullable type modifier
        public int Id { get; }
        public string CustomerName { get; }
        public string CustomerPhoneNumber { get; }
        public DateTime ReservationTime { get; }
        public int PartySize { get; }
        public bool IsConfirmed { get; }
        public string? CustomerEmail { get; }
        public string? SpecialRequests { get; }

        // [NOTE] One entry point for altering the object state
        public Reservation(int id, string customerName, string customerPhoneNumber, DateTime reservationTime,
                       int partySize, bool isConfirmed, string? customerEmail = null, string? specialRequests = null)
        {
            Id = id;
            CustomerName = customerName;
            CustomerPhoneNumber = customerPhoneNumber;
            ReservationTime = reservationTime;
            PartySize = partySize;
            IsConfirmed = isConfirmed;
            CustomerEmail = customerEmail;
            SpecialRequests = specialRequests;
        }
    }
}
