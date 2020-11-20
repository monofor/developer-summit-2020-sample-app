namespace Ecommerce.Api.Models
{
    public class ApiData<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}