namespace ProductApiDemo.Exceptions
{
    public class InvalidRequestException: ProductApiDemoException
    {
        public InvalidRequestException() : base() { }
        public InvalidRequestException(string message) : base(message) { }
    }
}
