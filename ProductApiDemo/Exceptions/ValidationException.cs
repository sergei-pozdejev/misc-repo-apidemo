namespace ProductApiDemo.Exceptions
{
    public class ValidationException: Exception
    {
        public string Type => "Validation exception";
        public override string Message => "One or more validation errors occurred.";
        public Dictionary<string, List<string>> ValidationErrors { get; set; } 
                = new Dictionary<string, List<string>>();

        public bool HasErrors => ValidationErrors.Any();
        public ValidationException() : base() { }
        public ValidationException(string message) : base(message) { }

        public void AddValidationError(string fieldName, string error)
        { 
            if(!ValidationErrors.ContainsKey(fieldName)) 
            { 
                ValidationErrors.Add(fieldName, new List<string>());
            }

            ValidationErrors[fieldName].Add(error);
        }
    }
}
