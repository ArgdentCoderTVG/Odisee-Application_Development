namespace Comme_Chez_Swa.Models
{
    // [NOTE] POCO with data integrity focus, solely instanced/manipulated using constructor (instance state is always intial state)
    public class ErrorViewModel
    {
        public string? RequestId { get; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // [NOTE] One entry point for altering the object state
        public ErrorViewModel(string requestId)
        {
            RequestId = requestId;
        }
    }
}