﻿// <auto-generated />
using System;
using Blood_donate_App_Backend.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Blood_donate_App_Backend.Migrations
{
    [DbContext(typeof(BloodDonateAppDbContext))]
    partial class BloodDonateAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Blood_donate_App_Backend.Models.CenterAdminRelation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CenterId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CenterId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("CenterAdminRelations");
                });

            modelBuilder.Entity("Blood_donate_App_Backend.Models.DonateBlood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BloodType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CenterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DonateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DonationStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RequestId")
                        .HasColumnType("int");

                    b.Property<string>("RhFactor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitsDonated")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CenterId");

                    b.HasIndex("RequestId");

                    b.HasIndex("UserId");

                    b.ToTable("DonateDetails");
                });

            modelBuilder.Entity("Blood_donate_App_Backend.Models.DonationCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OperatingHours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DonationCenters");
                });

            modelBuilder.Entity("Blood_donate_App_Backend.Models.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("AvailableStatus")
                        .HasColumnType("bit");

                    b.Property<string>("BloodType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CenterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CollectedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DonorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpiryDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("RhFactor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StorageLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Units")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CenterId");

                    b.HasIndex("DonorId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("Blood_donate_App_Backend.Models.RequestBlood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BloodType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoctorContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FulfillmentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HospitalAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HospitalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RejectReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestApprovalStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestedContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RequestedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("RhFactor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitsCollected")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitsNeeded")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Urgency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RequestDetails");
                });

            modelBuilder.Entity("Blood_donate_App_Backend.Models.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Blood_donate_App_Backend.Models.UserAuthDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<byte[]>("Password")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordHashKey")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("UsersAuthDetails");
                });

            modelBuilder.Entity("Blood_donate_App_Backend.Models.CenterAdminRelation", b =>
                {
                    b.HasOne("Blood_donate_App_Backend.Models.DonationCenter", "DonationCenter")
                        .WithOne("centerAdminRelation")
                        .HasForeignKey("Blood_donate_App_Backend.Models.CenterAdminRelation", "CenterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Blood_donate_App_Backend.Models.User", "User")
                        .WithMany("AdminForCenters")
                        .HasForeignKey("UserId")
                        .HasPrincipalKey("Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DonationCenter");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Blood_donate_App_Backend.Models.DonateBlood", b =>
                {
                    b.HasOne("Blood_donate_App_Backend.Models.DonationCenter", "DonatedInCenter")
                        .WithMany("BloodDonations")
                        .HasForeignKey("CenterId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Blood_donate_App_Backend.Models.RequestBlood", "DonatedToRequester")
                        .WithMany("BloodDonations")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Blood_donate_App_Backend.Models.User", "User")
                        .WithMany("DonateHistory")
                        .HasForeignKey("UserId")
                        .HasPrincipalKey("Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DonatedInCenter");

                    b.Navigation("DonatedToRequester");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Blood_donate_App_Backend.Models.Inventory", b =>
                {
                    b.HasOne("Blood_donate_App_Backend.Models.DonationCenter", "Center")
                        .WithMany("InventoryHistory")
                        .HasForeignKey("CenterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Blood_donate_App_Backend.Models.User", "Donor")
                        .WithMany("Inventories")
                        .HasForeignKey("DonorId")
                        .HasPrincipalKey("Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Center");

                    b.Navigation("Donor");
                });

            modelBuilder.Entity("Blood_donate_App_Backend.Models.RequestBlood", b =>
                {
                    b.HasOne("Blood_donate_App_Backend.Models.User", "User")
                        .WithMany("RequestHistory")
                        .HasForeignKey("UserId")
                        .HasPrincipalKey("Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Blood_donate_App_Backend.Models.UserAuthDetails", b =>
                {
                    b.HasOne("Blood_donate_App_Backend.Models.User", "User")
                        .WithOne("UserAuthDetails")
                        .HasForeignKey("Blood_donate_App_Backend.Models.UserAuthDetails", "Email")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Blood_donate_App_Backend.Models.DonationCenter", b =>
                {
                    b.Navigation("BloodDonations");

                    b.Navigation("InventoryHistory");

                    b.Navigation("centerAdminRelation")
                        .IsRequired();
                });

            modelBuilder.Entity("Blood_donate_App_Backend.Models.RequestBlood", b =>
                {
                    b.Navigation("BloodDonations");
                });

            modelBuilder.Entity("Blood_donate_App_Backend.Models.User", b =>
                {
                    b.Navigation("AdminForCenters");

                    b.Navigation("DonateHistory");

                    b.Navigation("Inventories");

                    b.Navigation("RequestHistory");

                    b.Navigation("UserAuthDetails")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
