namespace ApiTasks.DTOs
{
    public class Response
    {
        private int statusCode;
        private bool success;

        public int StatusCode { get => statusCode; set => statusCode = value; }
        public string? Message { get; set; }
        public bool Success { get => success; set => success = value; }
        public object? Data { get; set; }
        public object? Errors { get; set; }
    }
}
