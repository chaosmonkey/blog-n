﻿// <auto-generated />
using System;
using Blogn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Blogn.Data.Migrations
{
    [DbContext(typeof(BlogContext))]
    [Migration("20191219065241_AddResetTokens")]
    partial class AddResetTokens
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Blogn.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AvatarId")
                        .IsRequired()
                        .HasColumnType("VARCHAR(32)");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)")
                        .HasMaxLength(64);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(384)")
                        .HasMaxLength(384);

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.HasKey("Id")
                        .HasName("PK_Account")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("UK_Account_Email");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Blogn.Models.AccountRole", b =>
                {
                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AccountId", "Role");

                    b.ToTable("AccountRoles");
                });

            modelBuilder.Entity("Blogn.Models.Credentials", b =>
                {
                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateUpdated")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(256)");

                    b.HasKey("AccountId")
                        .HasName("PK_Credentials")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("Credentials");
                });

            modelBuilder.Entity("Blogn.Models.ResetToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CredentialsAccountId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("DateConsumed")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateCreated")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("DateExpired")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("VARCHAR(36)");

                    b.HasKey("Id")
                        .HasName("PK_ResetToken")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("CredentialsAccountId");

                    b.HasIndex("Token")
                        .IsUnique()
                        .HasName("UK_ResetToken_Token");

                    b.ToTable("ResetTokens");
                });

            modelBuilder.Entity("Blogn.Models.AccountRole", b =>
                {
                    b.HasOne("Blogn.Models.Account", "Account")
                        .WithMany("Roles")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Blogn.Models.Credentials", b =>
                {
                    b.HasOne("Blogn.Models.Account", "Account")
                        .WithOne("Credentials")
                        .HasForeignKey("Blogn.Models.Credentials", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Blogn.Models.ResetToken", b =>
                {
                    b.HasOne("Blogn.Models.Credentials", "Credentials")
                        .WithMany("ResetTokens")
                        .HasForeignKey("CredentialsAccountId");
                });
#pragma warning restore 612, 618
        }
    }
}
