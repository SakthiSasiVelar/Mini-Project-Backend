using System.ComponentModel;

namespace Blood_donate_App_Backend.Models
{
    public class User
    {
        public int Id { get; set; }
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

        public ICollection<RequestBlood> RequestHistory { get; set; }

        public ICollection<DonateBlood> DonateHistory { get; set; }

        public ICollection<Inventory> Inventories { get; set; }

        public UserAuthDetails UserAuthDetails { get; set; }

        public ICollection<CenterAdminRelation>  AdminForCenters{ get; set;}
    }
}
