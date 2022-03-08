namespace DataLayer.Responses
{
    public class ResponseBase<T> where T : class
    {
        public T? Data { get; set; }
        private bool Success { get; set; } = true;
        private string ErrorMessage { get; set; }
    }
}