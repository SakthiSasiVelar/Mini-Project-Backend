namespace Blood_donate_App_Backend.Models.DTOs
{
    public class ErrorModel
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public ErrorModel(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
