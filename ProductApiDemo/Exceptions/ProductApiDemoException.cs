namespace ProductApiDemo.Exceptions
{
    public class ProductApiDemoException : Exception
    {
        public virtual string Type => "Product Api Demo Exception";

        public ProductApiDemoException() : base() { }
        public ProductApiDemoException(string message) : base(message) { }
    }
}
