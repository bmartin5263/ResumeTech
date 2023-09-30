﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ResumeTech.Persistence.EntityFramework;

#nullable disable

namespace ResumeTech.Persistence.EntityFramework.Migrations
{
    [DbContext(typeof(EFCoreContext))]
    partial class EFCoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.DeviceFlowCodes", b =>
                {
                    b.Property<string>("UserCode")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("character varying(50000)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("DeviceCode")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateTime?>("Expiration")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("UserCode");

                    b.HasIndex("DeviceCode")
                        .IsUnique();

                    b.HasIndex("Expiration");

                    b.ToTable("DeviceCodes", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.Key", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Algorithm")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("DataProtected")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsX509Certificate")
                        .HasColumnType("boolean");

                    b.Property<string>("Use")
                        .HasColumnType("text");

                    b.Property<int>("Version")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Use");

                    b.ToTable("Keys", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.PersistedGrant", b =>
                {
                    b.Property<string>("Key")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateTime?>("ConsumedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(50000)
                        .HasColumnType("character varying(50000)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SessionId")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("SubjectId")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Key");

                    b.HasIndex("ConsumedTime");

                    b.HasIndex("Expiration");

                    b.HasIndex("SubjectId", "ClientId", "Type");

                    b.HasIndex("SubjectId", "SessionId", "Type");

                    b.ToTable("PersistedGrants", (string)null);
                });

            modelBuilder.Entity("ResumeTech.Experiences.Contacts.ContactInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("ContactInfoId");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Links")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("jsonb")
                        .HasDefaultValueSql("'[]'::jsonb");

                    b.Property<Guid>("ProfileId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("ContactInfo", (string)null);
                });

            modelBuilder.Entity("ResumeTech.Experiences.Educations.Education", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("EducationId");

                    b.Property<string>("AreaOfStudy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BulletPoints")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DegreeType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProfileId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Education", (string)null);
                });

            modelBuilder.Entity("ResumeTech.Experiences.Jobs.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("JobId");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProfileId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ProfileId");

                    b.ToTable("Job", (string)null);
                });

            modelBuilder.Entity("ResumeTech.Experiences.Jobs.Position", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("PositionId");

                    b.Property<string>("BulletPoints")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("jsonb")
                        .HasDefaultValueSql("'[]'::jsonb");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid>("JobId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("Position", (string)null);
                });

            modelBuilder.Entity("ResumeTech.Experiences.Profiles.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("ProfileId");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Profile", (string)null);
                });

            modelBuilder.Entity("ResumeTech.Identities.Duende.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("ResumeTech.Identities.Duende.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim", (string)null);
                });

            modelBuilder.Entity("ResumeTech.Identities.Duende.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("RefreshToken")
                        .HasColumnType("uuid");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("ResumeTech.Identities.Duende.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim", (string)null);
                });

            modelBuilder.Entity("ResumeTech.Identities.Duende.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin", (string)null);
                });

            modelBuilder.Entity("ResumeTech.Identities.Duende.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole", (string)null);
                });

            modelBuilder.Entity("ResumeTech.Identities.Duende.UserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserToken", (string)null);
                });

            modelBuilder.Entity("ResumeTech.Experiences.Contacts.ContactInfo", b =>
                {
                    b.HasOne("ResumeTech.Experiences.Profiles.Profile", null)
                        .WithMany("ContactInfos")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ResumeTech.Experiences.Contacts.Location", "Location", b1 =>
                        {
                            b1.Property<Guid>("ContactInfoId")
                                .HasColumnType("uuid");

                            b1.Property<string>("City")
                                .HasColumnType("text")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .HasColumnType("text")
                                .HasColumnName("Country");

                            b1.Property<string>("State")
                                .HasColumnType("text")
                                .HasColumnName("State");

                            b1.HasKey("ContactInfoId");

                            b1.ToTable("ContactInfo");

                            b1.WithOwner()
                                .HasForeignKey("ContactInfoId");
                        });

                    b.OwnsOne("ResumeTech.Experiences.Contacts.PersonName", "Name", b1 =>
                        {
                            b1.Property<Guid>("ContactInfoId")
                                .HasColumnType("uuid");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("FirstName");

                            b1.Property<string>("LastName")
                                .HasColumnType("text")
                                .HasColumnName("LastName");

                            b1.Property<string>("MiddleName")
                                .HasColumnType("text")
                                .HasColumnName("MiddleName");

                            b1.HasKey("ContactInfoId");

                            b1.ToTable("ContactInfo");

                            b1.WithOwner()
                                .HasForeignKey("ContactInfoId");
                        });

                    b.Navigation("Location")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("ResumeTech.Experiences.Educations.Education", b =>
                {
                    b.HasOne("ResumeTech.Experiences.Profiles.Profile", null)
                        .WithMany("Educations")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ResumeTech.Experiences.Contacts.Location", "Location", b1 =>
                        {
                            b1.Property<Guid>("EducationId")
                                .HasColumnType("uuid");

                            b1.Property<string>("City")
                                .HasColumnType("text")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .HasColumnType("text")
                                .HasColumnName("Country");

                            b1.Property<string>("State")
                                .HasColumnType("text")
                                .HasColumnName("State");

                            b1.HasKey("EducationId");

                            b1.ToTable("Education");

                            b1.WithOwner()
                                .HasForeignKey("EducationId");
                        });

                    b.OwnsOne("ResumeTech.Experiences.Educations.Gpa", "Gpa", b1 =>
                        {
                            b1.Property<Guid>("EducationId")
                                .HasColumnType("uuid");

                            b1.Property<decimal>("Scale")
                                .HasColumnType("numeric")
                                .HasColumnName("GpaScale");

                            b1.Property<decimal>("Value")
                                .HasColumnType("numeric")
                                .HasColumnName("GpaValue");

                            b1.HasKey("EducationId");

                            b1.ToTable("Education");

                            b1.WithOwner()
                                .HasForeignKey("EducationId");
                        });

                    b.Navigation("Gpa");

                    b.Navigation("Location")
                        .IsRequired();
                });

            modelBuilder.Entity("ResumeTech.Experiences.Jobs.Job", b =>
                {
                    b.HasOne("ResumeTech.Experiences.Profiles.Profile", null)
                        .WithMany("Jobs")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ResumeTech.Experiences.Contacts.Location", "Location", b1 =>
                        {
                            b1.Property<Guid>("JobId")
                                .HasColumnType("uuid");

                            b1.Property<string>("City")
                                .HasColumnType("text")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .HasColumnType("text")
                                .HasColumnName("Country");

                            b1.Property<string>("State")
                                .HasColumnType("text")
                                .HasColumnName("State");

                            b1.HasKey("JobId");

                            b1.ToTable("Job");

                            b1.WithOwner()
                                .HasForeignKey("JobId");
                        });

                    b.Navigation("Location")
                        .IsRequired();
                });

            modelBuilder.Entity("ResumeTech.Experiences.Jobs.Position", b =>
                {
                    b.HasOne("ResumeTech.Experiences.Jobs.Job", null)
                        .WithMany("Positions")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ResumeTech.Experiences.Common.DateOnlyRange", "Dates", b1 =>
                        {
                            b1.Property<Guid>("PositionId")
                                .HasColumnType("uuid");

                            b1.Property<DateOnly?>("End")
                                .HasColumnType("date")
                                .HasColumnName("EndDate");

                            b1.Property<DateOnly?>("Start")
                                .HasColumnType("date")
                                .HasColumnName("StartDate");

                            b1.HasKey("PositionId");

                            b1.ToTable("Position");

                            b1.WithOwner()
                                .HasForeignKey("PositionId");
                        });

                    b.Navigation("Dates")
                        .IsRequired();
                });

            modelBuilder.Entity("ResumeTech.Identities.Duende.RoleClaim", b =>
                {
                    b.HasOne("ResumeTech.Identities.Duende.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ResumeTech.Identities.Duende.UserClaim", b =>
                {
                    b.HasOne("ResumeTech.Identities.Duende.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ResumeTech.Identities.Duende.UserLogin", b =>
                {
                    b.HasOne("ResumeTech.Identities.Duende.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ResumeTech.Identities.Duende.UserRole", b =>
                {
                    b.HasOne("ResumeTech.Identities.Duende.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ResumeTech.Identities.Duende.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ResumeTech.Identities.Duende.UserToken", b =>
                {
                    b.HasOne("ResumeTech.Identities.Duende.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ResumeTech.Experiences.Jobs.Job", b =>
                {
                    b.Navigation("Positions");
                });

            modelBuilder.Entity("ResumeTech.Experiences.Profiles.Profile", b =>
                {
                    b.Navigation("ContactInfos");

                    b.Navigation("Educations");

                    b.Navigation("Jobs");
                });
#pragma warning restore 612, 618
        }
    }
}
