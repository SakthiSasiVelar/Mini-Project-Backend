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
