namespace ProductApiDemo.Exceptions
{
    public class PageNotFoundException: ProductApiDemoException
    {
        public PageNotFoundException(string message) : base(message) { }
    }
}
