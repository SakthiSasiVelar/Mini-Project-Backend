using System.ComponentModel.DataAnnotations;

namespace Blood_donate_App_Backend.Models.DTOs
{
    public class RejectBloodRequestDTO
    {
        [Required(ErrorMessage = "Request id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Reject reason  is required")]
        public string RejectReason { get; set; }
    }
}
