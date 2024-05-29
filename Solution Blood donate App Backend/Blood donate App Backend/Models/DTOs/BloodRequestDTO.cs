using System.ComponentModel.DataAnnotations;

namespace Blood_donate_App_Backend.Models.DTOs
{
    public class BloodRequestDTO
    {
        [Required(ErrorMessage = "User Id is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Patient Name is required")]
        public string PatientName { get; set; }

        [Required(ErrorMessage = "Blood type is required")]
        public string BloodType { get; set; }

        [Required(ErrorMessage = "Rh factor is required")]
        public string RhFactor { get; set; }

        [Required(ErrorMessage = "Units needed is required")]
        public string UnitsNeeded { get; set; }

        [Required(ErrorMessage = "Urgency is required")]
        public string Urgency { get; set; }

        [Required(ErrorMessage = "Request Contact Number is required")]
        public string RequestedContactNumber { get; set; }

        [Required(ErrorMessage = "Request Date Time is required")]
        public DateTime RequestedDateTime { get; set; }

        [Required(ErrorMessage = "description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Hospital name is required")]
        public string HospitalName { get; set; }

        [Required(ErrorMessage = "Hospital address is required")]
        public string HospitalAddress { get; set; }

        [Required(ErrorMessage = "Doctor name is required")]
        public string DoctorName { get; set; }

        [Required(ErrorMessage = "Doctor contact number is required")]
        public string DoctorContactNumber { get; set; }
    }
}
