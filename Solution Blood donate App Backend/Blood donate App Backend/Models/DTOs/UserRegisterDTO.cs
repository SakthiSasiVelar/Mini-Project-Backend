namespace Blood_donate_App_Backend.Models.DTOs
{
    public class UserRegisterDTO
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string ContactNumber { get; set; }

        public string Role { get; set; }

        public int CenterId { get; set; } = -1;

        public string Password { get; set; }
 
    }
}
