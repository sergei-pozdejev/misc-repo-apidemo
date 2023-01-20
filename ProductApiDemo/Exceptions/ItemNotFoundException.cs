namespace ProductApiDemo.Exceptions
{
    public class ItemNotFoundException: ProductApiDemoException
    {
        public ItemNotFoundException(string message):base(message) { }
    }
}
