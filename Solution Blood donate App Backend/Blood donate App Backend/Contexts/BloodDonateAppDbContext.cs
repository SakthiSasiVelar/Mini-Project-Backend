using Blood_donate_App_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Blood_donate_App_Backend.Contexts
{
    public class BloodDonateAppDbContext : DbContext
    {
        public BloodDonateAppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<UserAuthDetails> UsersAuthDetails { get; set; }

        public DbSet<RequestBlood> RequestDetails { get; set; }

        public DbSet<DonateBlood> DonateDetails { get; set; }

        public DbSet<CenterAdminRelation> CenterAdminRelations { get; set;}

        public DbSet<Inventory> Inventory { get; set; }

        public DbSet<DonationCenter> DonationCenters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().HasKey(u => u.Email);
            modelBuilder.Entity<UserAuthDetails>().HasKey(userAuthDetails => userAuthDetails.Id);
            modelBuilder.Entity<DonationCenter>().HasKey(donationCenter => donationCenter.Id);
            modelBuilder.Entity<CenterAdminRelation>().HasKey(centerAdmin => centerAdmin.Id);
            modelBuilder.Entity<Inventory>().HasKey(inventory => inventory.Id);
            modelBuilder.Entity<RequestBlood>().HasKey(request => request.Id);
            modelBuilder.Entity<DonateBlood>().HasKey(donate => donate.Id);

            modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 101,
                Name = "sakthi",
                Address = "101 abc street",
                City = "cbe",
                ContactNumber = "1234567890",
                Email = "sakthi@gmail.com",
                PostalCode = "641668",
                State = "tamil nadu",
                Gender = "Male",
                DateOfBirth = DateTime.Now,
                Role = "Admin"
            },
            new User
            {
                Id = 102,
                Name = "sachin",
                Address = "101 abc street",
                City = "cbe",
                ContactNumber = "1234567890",
                Email = "sachin@gmail.com",
                PostalCode = "641668",
                State = "tamil nadu",
                Gender = "Male",
                DateOfBirth = DateTime.Now,
                Role = "Member"
            },
            new User
            {
                Id = 103,
                Name = "ROHIT",
                Address = "101 abc street",
                City = "cbe",
                ContactNumber = "1234567890",
                Email = "rohit@gmail.com",
                PostalCode = "641668",
                State = "tamil nadu",
                Gender = "Male",
                DateOfBirth = DateTime.Now,
                Role = "CenterAdmin"
            }
            );

            modelBuilder.Entity<RequestBlood>().HasData(
                new RequestBlood
                {
                    Id = 101,
                    UserId = 102,
                    BloodType = "A",
                    RhFactor = "positive",
                    UnitsNeeded = "50",
                    UnitsCollected = "0",
                    Urgency = "Immediate",
                    RequestedDateTime = DateTime.Now,
                    Description = "need A+ blood",
                    FulfillmentStatus = "NotFulfilled",
                    HospitalName = "KMCH",
                    HospitalAddress = "123 , ABC cbe",
                    DoctorName = "sasi",
                    DoctorContactNumber = "1234567890",
                    RequestedContactNumber = "12345656789",
                    RequestApprovalStatus = "Approved",
                    PatientName = "ramu",
                    RejectReason = "NULL"
                },
                 new RequestBlood
                 {
                     Id = 102,
                     UserId = 102,
                     BloodType = "B",
                     RhFactor = "positive",
                     UnitsNeeded = "50",
                     UnitsCollected = "0",
                     Urgency = "Immediate",
                     RequestedDateTime = DateTime.Now,
                     Description = "need b+ blood",
                     FulfillmentStatus = "NotFulfilled",
                     HospitalName = "KMCH",
                     HospitalAddress = "123 , ABC cbe",
                     DoctorName = "sasi",
                     DoctorContactNumber = "1234567890",
                     RequestedContactNumber = "12345656789",
                     RequestApprovalStatus = "Pending",
                     PatientName = "ramu",
                     RejectReason = "NULL"
                 });

            modelBuilder.Entity<DonateBlood>().HasData(
                new DonateBlood
                {
                    Id = 101,
                    UserId = 102,
                    DonationType = "Requester",
                    CenterId = null,
                    RequestId = 102,
                    BloodType = "B",
                    RhFactor = "positive",
                    DonationStatus = "NotDonated",
                    UnitsDonated = "5",
                    DonateDateTime = DateTime.Now,
                },

                new DonateBlood
                {
                    Id = 102,
                    UserId = 102,
                    DonationType = "Center",
                    CenterId = 101,
                    RequestId = null,
                    BloodType = "O",
                    RhFactor = "positive",
                    DonationStatus = "Donated",
                    UnitsDonated = "5",
                    DonateDateTime = DateTime.Now,
                },
                new DonateBlood
                {
                    Id = 103,
                    UserId = 102,
                    DonationType = "Center",
                    CenterId = 102,
                    RequestId = null,
                    BloodType = "AB",
                    RhFactor = "positive",
                    DonationStatus = "NotDonated",
                    UnitsDonated = "5",
                    DonateDateTime = DateTime.Now,
                },
                 new DonateBlood
                 {
                     Id = 104,
                     UserId = 102,
                     DonationType = "Requester",
                     CenterId = null,
                     RequestId = 101,
                     BloodType = "A",
                     RhFactor = "positive",
                     DonationStatus = "NotDonated",
                     UnitsDonated = "50",
                     DonateDateTime = DateTime.Now,
                 },
                  new DonateBlood
                  {
                      Id = 105,
                      UserId = 102,
                      DonationType = "Requester",
                      CenterId = null,
                      RequestId = 110,
                      BloodType = "A",
                      RhFactor = "positive",
                      DonationStatus = "NotDonated",
                      UnitsDonated = "50",
                      DonateDateTime = DateTime.Now,
                  }

                );
            modelBuilder.Entity<DonationCenter>().HasData(
                new DonationCenter
                {
                    Id = 101,
                    Name = "center 1",
                    Address = "100 abc street cbe",
                    City = "cbe",
                    State = "tamil nadu",
                    PostalCode = "641668",
                    ContactNumber = "1234567890",
                    OperatingHours = "10 AM to 4 PM"
                },
                new DonationCenter
                {
                    Id = 102,
                    Name = "center 2",
                    Address = "100 abc street trichy",
                    City = "trichy",
                    State = "tamil nadu",
                    PostalCode = "641668",
                    ContactNumber = "1234567890",
                    OperatingHours = "10 AM to 4 PM"
                }
            );
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory
                {
                    Id = 101,
                    CenterId = 101,
                    DonorId = 102,
                    BloodType = "O",
                    RhFactor = "positive",
                    Units = "5",
                    CollectedDateTime = DateTime.Now,
                    ExpiryDateTime = DateTime.Now,
                    StorageLocation = "1 rack",
                    AvailableStatus = true
                }
            );
            modelBuilder.Entity<CenterAdminRelation>().HasData(
                new CenterAdminRelation
                {
                    Id = 101,
                    CenterId = 101,
                    UserId = 103
                }
                );

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .ValueGeneratedNever();

            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<RequestBlood>()
                .HasOne(rb => rb.User)
                .WithMany(u => u.RequestHistory)
                .HasForeignKey(rb => rb.UserId)
                .HasPrincipalKey(u => u.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DonateBlood>()
                .HasOne(db => db.User)
                .WithMany(u => u.DonateHistory)
                .HasForeignKey(db => db.UserId)
                .HasPrincipalKey(u => u.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DonateBlood>()
                .HasOne(db => db.DonatedInCenter)
                .WithMany(dc => dc.BloodDonations)
                .HasForeignKey(db => db.CenterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DonateBlood>()
                .HasOne(db => db.DonatedToRequester)
                .WithMany(rb => rb.BloodDonations)
                .HasForeignKey(db => db.RequestId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserAuthDetails>()
                .HasOne(uad => uad.User)
                .WithOne(u => u.UserAuthDetails)
                .HasForeignKey<UserAuthDetails>(uad => uad.Email)
                .HasPrincipalKey<User>(u => u.Email)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Inventory>()
                .HasOne(i => i.Center)
                .WithMany(dc => dc.InventoryHistory)
                .HasForeignKey(i => i.CenterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Inventory>()
                .HasOne(i => i.Donor)
                .WithMany(u => u.Inventories)
                .HasForeignKey(i => i.DonorId)
                .HasPrincipalKey(u => u.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CenterAdminRelation>()
                .HasOne(ca => ca.User)
                .WithMany(u => u.AdminForCenters)
                .HasForeignKey(ca => ca.UserId)
                .HasPrincipalKey(u => u.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CenterAdminRelation>()
                .HasOne(ca => ca.DonationCenter)
                .WithMany(dc => dc.Admins)
                .HasForeignKey(ca => ca.CenterId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
