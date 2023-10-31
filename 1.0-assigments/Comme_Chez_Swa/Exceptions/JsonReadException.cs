namespace Comme_Chez_Swa.Exceptions
{
    [Serializable]
    public class JsonReadException : Exception
    {
        // Default constructor
        public JsonReadException()
            : base("An error occurred while reading the JSON data.") { }

        // Constructor that accepts a specific message
        public JsonReadException(string message)
            : base(message) { }

        // Constructor that accepts a message and an inner exception
        public JsonReadException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
