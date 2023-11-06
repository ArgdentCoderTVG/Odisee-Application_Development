namespace Comme_Chez_Swa.Models.Reservatie.Utility
{
    // Explicit intent principle: Default value of enum is zero, so zero shouldn't be an non-default meaningless value.
    public enum ReservatieTijdstip
    {
        None = 0,
        Ochtend = 1,
        Middag = 2,
        Avond = 3
    }
}
