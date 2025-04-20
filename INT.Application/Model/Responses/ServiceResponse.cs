namespace INT.Application.Model.Responses
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
    public class ServiceResponse
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
