
using Microsoft.AspNetCore.Mvc.ModelBinding;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Blood_donate_App_Backend.Models.DTOs
{
    public class ValidationErrorModel
    {
        public int StatusCode { get; set; }

        public List<string> Errors { get; set; }

        public string Status { get; set; }

        public ValidationErrorModel(int statusCode, ModelStateDictionary modelState)
        {
            StatusCode = statusCode;
            Status = "error";
            Errors = modelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();
        }
    }
}
