using ProductApiDemo.Exceptions;

namespace ProductApiDemo.Models
{
    public class ErrorResponse
    {

        /// <summary>
        /// Error type
        /// </summary>
        public string Type { get; set; }        
        
        /// <summary>
        /// Error message/title
        /// </summary>
        public string Title { get; set; }        
        
        /// <summary>
        /// Response HTTP status
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Log trace id
        /// </summary>
        public string TraceId { get; set; }        
        
        /// <summary>
        /// Dictionary of occured errors. 
        /// Useful for validation exceptions, 
        /// where field name will be Key and Value will be list of errors
        /// </summary>
        public Dictionary<string, IEnumerable<string>> Errors { get; set; } = new Dictionary<string, IEnumerable<string>>();

       
        public static ErrorResponse FromException(Guid traceID, int status, ProductApiDemoException exception)        
            => FromException(traceID, status, exception.Type, (Exception)exception);
        

        public static ErrorResponse FromException(Guid traceID, int status, ValidationException exception)
        {
            return new ErrorResponse
            {
                Type = exception.Type,
                Title = exception.Message,
                Status = status,
                TraceId = traceID.ToString(),
                Errors = exception.ValidationErrors.ToDictionary(x => x.Key, x => x.Value.AsEnumerable())
            };
        }
        public static ErrorResponse FromException(Guid traceID, int status, string type, Exception exception)
        {
            return new ErrorResponse
            {
                Type = type,
                Title = exception.Message,
                Status = status,
                TraceId = traceID.ToString(),
                Errors = new Dictionary<string, IEnumerable<string>>
                {
                    {
                        type, new List<String> { exception.Message }
                    }
                }
            };
        }
    }
}
