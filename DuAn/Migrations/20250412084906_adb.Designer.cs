﻿// <auto-generated />
using System;
using DuAn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DuAn.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20250412084906_adb")]
    partial class adb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DuAn.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("DuAn.Models.Cartdetails", b =>
                {
                    b.Property<int>("MaChiTietGioHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaChiTietGioHang"));

                    b.Property<double>("Gia")
                        .HasColumnType("float");

                    b.Property<string>("Loai")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("MaCombo")
                        .HasColumnType("int");

                    b.Property<int?>("MaGioHang")
                        .HasColumnType("int");

                    b.Property<int?>("MaMonAn")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaChiTietGioHang")
                        .HasName("PK__ChiTietG__BBF4749862250370");

                    b.HasIndex("MaCombo");

                    b.HasIndex("MaGioHang");

                    b.HasIndex("MaMonAn");

                    b.ToTable("ChiTietGioHang", (string)null);
                });

            modelBuilder.Entity("DuAn.Models.Combo", b =>
                {
                    b.Property<int>("MaCombo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaCombo"));

                    b.Property<string>("DuongDanHinh")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<double>("Gia")
                        .HasColumnType("float");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TenCombo")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaCombo")
                        .HasName("PK__Combo__C3EDBC780AF5616F");

                    b.ToTable("Combo", (string)null);
                });

            modelBuilder.Entity("DuAn.Models.Combodetails", b =>
                {
                    b.Property<int>("MaCombo")
                        .HasColumnType("int");

                    b.Property<int>("MaMonAn")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("MaCombo", "MaMonAn")
                        .HasName("PK__ChiTietC__88FCCD1AF6756E4F");

                    b.HasIndex("MaMonAn");

                    b.ToTable("ChiTietCombo", (string)null);
                });

            modelBuilder.Entity("DuAn.Models.Dish", b =>
                {
                    b.Property<int>("MaMonAn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaMonAn"));

                    b.Property<string>("DuongDanHinh")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<double>("Gia")
                        .HasColumnType("float");

                    b.Property<int?>("MaTag")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("Soluong")
                        .HasColumnType("int");

                    b.Property<string>("TenMonAn")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool?>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaMonAn")
                        .HasName("PK__MonAn__B1171625E776C924");

                    b.HasIndex("MaTag");

                    b.ToTable("MonAn", (string)null);
                });

            modelBuilder.Entity("DuAn.Models.Order", b =>
                {
                    b.Property<int>("MaDonHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDonHang"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaNguoiDung")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ThoiGianDat")
                        .HasColumnType("datetime");

                    b.Property<double>("TongTien")
                        .HasColumnType("float");

                    b.Property<string>("TrangThai")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaDonHang");

                    b.HasIndex("MaNguoiDung");

                    b.ToTable("DonHangs");
                });

            modelBuilder.Entity("DuAn.Models.Orderdetails", b =>
                {
                    b.Property<int>("MaChiTietDonHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaChiTietDonHang"));

                    b.Property<string>("DiaChiNhanHang")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<double>("Gia")
                        .HasColumnType("float");

                    b.Property<int?>("MaCombo")
                        .HasColumnType("int");

                    b.Property<int?>("MaDonHang")
                        .HasColumnType("int");

                    b.Property<int?>("MaMonAn")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("lyDoHuyDon")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("MaChiTietDonHang")
                        .HasName("PK__ChiTietD__4B0B45DD1A75C737");

                    b.HasIndex("MaCombo");

                    b.HasIndex("MaDonHang");

                    b.HasIndex("MaMonAn");

                    b.ToTable("ChiTietDonHang", (string)null);
                });

            modelBuilder.Entity("DuAn.Models.ShoppingCart", b =>
                {
                    b.Property<int>("MaGioHang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaGioHang"));

                    b.Property<string>("MaNguoiDung")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MaGioHang");

                    b.HasIndex("MaNguoiDung");

                    b.ToTable("GioHangs");
                });

            modelBuilder.Entity("DuAn.Models.Tag", b =>
                {
                    b.Property<int>("MaTag")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaTag"));

                    b.Property<string>("TenTag")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.HasKey("MaTag")
                        .HasName("PK__Tag__314EC2148ECC02F7");

                    b.ToTable("Tag", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DuAn.Models.Cartdetails", b =>
                {
                    b.HasOne("DuAn.Models.Combo", "MaComboNavigation")
                        .WithMany("ChiTietGioHangs")
                        .HasForeignKey("MaCombo")
                        .HasConstraintName("FK__ChiTietGi__MaCom__5070F446");

                    b.HasOne("DuAn.Models.ShoppingCart", "MaGioHangNavigation")
                        .WithMany("ChiTietGioHangs")
                        .HasForeignKey("MaGioHang")
                        .HasConstraintName("FK__ChiTietGi__MaGio__4E88ABD4");

                    b.HasOne("DuAn.Models.Dish", "MaMonAnNavigation")
                        .WithMany("ChiTietGioHangs")
                        .HasForeignKey("MaMonAn")
                        .HasConstraintName("FK__ChiTietGi__MaMon__4F7CD00D");

                    b.Navigation("MaComboNavigation");

                    b.Navigation("MaGioHangNavigation");

                    b.Navigation("MaMonAnNavigation");
                });

            modelBuilder.Entity("DuAn.Models.Combodetails", b =>
                {
                    b.HasOne("DuAn.Models.Combo", "MaComboNavigation")
                        .WithMany("ChiTietCombos")
                        .HasForeignKey("MaCombo")
                        .IsRequired()
                        .HasConstraintName("FK__ChiTietCo__MaCom__3E52440B");

                    b.HasOne("DuAn.Models.Dish", "MaMonAnNavigation")
                        .WithMany("ChiTietCombos")
                        .HasForeignKey("MaMonAn")
                        .IsRequired()
                        .HasConstraintName("FK__ChiTietCo__MaMon__3F466844");

                    b.Navigation("MaComboNavigation");

                    b.Navigation("MaMonAnNavigation");
                });

            modelBuilder.Entity("DuAn.Models.Dish", b =>
                {
                    b.HasOne("DuAn.Models.Tag", "MaTagNavigation")
                        .WithMany("MonAns")
                        .HasForeignKey("MaTag")
                        .HasConstraintName("FK__MonAn__MaTag__398D8EEE");

                    b.Navigation("MaTagNavigation");
                });

            modelBuilder.Entity("DuAn.Models.Order", b =>
                {
                    b.HasOne("DuAn.Models.ApplicationUser", "MaNguoiDungNavigation")
                        .WithMany("DonHangs")
                        .HasForeignKey("MaNguoiDung")
                        .HasConstraintName("FK_DonHang_User");

                    b.Navigation("MaNguoiDungNavigation");
                });

            modelBuilder.Entity("DuAn.Models.Orderdetails", b =>
                {
                    b.HasOne("DuAn.Models.Combo", "MaComboNavigation")
                        .WithMany("ChiTietDonHangs")
                        .HasForeignKey("MaCombo")
                        .HasConstraintName("FK__ChiTietDo__MaCom__48CFD27E");

                    b.HasOne("DuAn.Models.Order", "MaDonHangNavigation")
                        .WithMany("ChiTietDonHangs")
                        .HasForeignKey("MaDonHang")
                        .HasConstraintName("FK__ChiTietDo__MaDon__46E78A0C");

                    b.HasOne("DuAn.Models.Dish", "MaMonAnNavigation")
                        .WithMany("ChiTietDonHangs")
                        .HasForeignKey("MaMonAn")
                        .HasConstraintName("FK__ChiTietDo__MaMon__47DBAE45");

                    b.Navigation("MaComboNavigation");

                    b.Navigation("MaDonHangNavigation");

                    b.Navigation("MaMonAnNavigation");
                });

            modelBuilder.Entity("DuAn.Models.ShoppingCart", b =>
                {
                    b.HasOne("DuAn.Models.ApplicationUser", "MaNguoiDungNavigation")
                        .WithMany("GioHangs")
                        .HasForeignKey("MaNguoiDung")
                        .HasConstraintName("FK_GioHang_User");

                    b.Navigation("MaNguoiDungNavigation");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DuAn.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DuAn.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DuAn.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DuAn.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DuAn.Models.ApplicationUser", b =>
                {
                    b.Navigation("DonHangs");

                    b.Navigation("GioHangs");
                });

            modelBuilder.Entity("DuAn.Models.Combo", b =>
                {
                    b.Navigation("ChiTietCombos");

                    b.Navigation("ChiTietDonHangs");

                    b.Navigation("ChiTietGioHangs");
                });

            modelBuilder.Entity("DuAn.Models.Dish", b =>
                {
                    b.Navigation("ChiTietCombos");

                    b.Navigation("ChiTietDonHangs");

                    b.Navigation("ChiTietGioHangs");
                });

            modelBuilder.Entity("DuAn.Models.Order", b =>
                {
                    b.Navigation("ChiTietDonHangs");
                });

            modelBuilder.Entity("DuAn.Models.ShoppingCart", b =>
                {
                    b.Navigation("ChiTietGioHangs");
                });

            modelBuilder.Entity("DuAn.Models.Tag", b =>
                {
                    b.Navigation("MonAns");
                });
#pragma warning restore 612, 618
        }
    }
}
