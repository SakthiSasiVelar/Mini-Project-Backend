using Microsoft.VisualBasic;

namespace Blood_donate_App_Backend.Models.DTOs
{
    public class SuccessResponseModel<T> where T : class
    {
        public string Message { get; set; }

        public int StatusCode { get; set; }

        public string Status {  get; set; }

        public T Data { get; set; }

        public SuccessResponseModel(int statusCode , string message , T data ) 
        {
            Status = "success";
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }
    }
}
