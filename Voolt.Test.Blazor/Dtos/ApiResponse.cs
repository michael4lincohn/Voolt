namespace Voolt.Test.Blazor.Dtos
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public int Total { get; set; }
    }
}