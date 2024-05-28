namespace Blood_donate_App_Backend.Models
{
    public class DonationCenter
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public string ContactNumber { get; set; }

        public string OperatingHours { get; set; }

        public ICollection<Inventory> InventoryHistory { get; set; }

        public ICollection<DonateBlood> BloodDonations { get; set; }

        public ICollection<CenterAdminRelation> Admins { get; set; }

    }
}
