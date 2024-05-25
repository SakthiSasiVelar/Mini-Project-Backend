namespace Blood_donate_App_Backend.Models
{
    public class UserAuthDetails
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public User User { get; set; }

        public byte[] Password { get; set; }

        public string Role { get; set; }

        public byte[] PasswordHashKey { get; set; }

        public bool IsActive { get; set; }
    }
}
