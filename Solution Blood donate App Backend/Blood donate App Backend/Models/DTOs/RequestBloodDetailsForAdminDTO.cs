namespace Blood_donate_App_Backend.Models.DTOs
{
    public class RequestBloodDetailsForAdminDTO
    {
        public int RequestId { get; set; }

        public int RequestedUserId { get; set; }

        public string PatientName { get; set; }

        public string BloodType { get; set; }

        public string RhFactor { get; set; }

        public string UnitsNeeded { get; set; }

        public string UnitsCollected { get; set; }

        public string Urgency { get; set; }

        public string RequestedContactNumber { get; set; }

        public DateTime RequestedDateTime { get; set; }

        public string Description { get; set; }

        public string RequestApprovalStatus { get; set; }

        public string FulfillmentStatus { get; set; }

        public string HospitalName { get; set; }

        public string HospitalAddress { get; set; }

        public string DoctorName { get; set; }

        public string DoctorContactNumber { get; set; }
    }
}
