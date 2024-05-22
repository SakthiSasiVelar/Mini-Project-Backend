using System.ComponentModel.DataAnnotations.Schema;

namespace Blood_donate_App_Backend.Models
{
    public class CenterAdminRelation
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int CenterId { get; set; }

        public DonationCenter DonationCenter { get; set; }
    }
}
