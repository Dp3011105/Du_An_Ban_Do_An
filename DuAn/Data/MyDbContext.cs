﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DuAn.Models;
using Microsoft.EntityFrameworkCore;

namespace DuAn.Data
{
	public partial class MyDbContext : IdentityDbContext<ApplicationUser>
	{





		public MyDbContext()
		{
		}
		public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
		public virtual DbSet<Combodetails> ChiTietCombos { get; set; }

		public virtual DbSet<Orderdetails> ChiTietDonHangs { get; set; }

		public virtual DbSet<Cartdetails> ChiTietGioHangs { get; set; }

		public virtual DbSet<Combo> Combos { get; set; }

		public virtual DbSet<Order> DonHangs { get; set; }

		public virtual DbSet<ShoppingCart> GioHangs { get; set; }

		public virtual DbSet<Dish> MonAns { get; set; }


		public virtual DbSet<Tag> Tags { get; set; }



		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Combodetails>(entity =>
			{
				entity.HasKey(e => new { e.MaCombo, e.MaMonAn }).HasName("PK__ChiTietC__88FCCD1AF6756E4F");

				entity.ToTable("ChiTietCombo");

				entity.HasOne(d => d.MaComboNavigation).WithMany(p => p.ChiTietCombos)
					.HasForeignKey(d => d.MaCombo)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__ChiTietCo__MaCom__3E52440B");

				entity.HasOne(d => d.MaMonAnNavigation).WithMany(p => p.ChiTietCombos)
					.HasForeignKey(d => d.MaMonAn)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK__ChiTietCo__MaMon__3F466844");
			});

            modelBuilder.Entity<Orderdetails>(entity =>
            {
                entity.HasKey(e => e.MaChiTietDonHang).HasName("PK__ChiTietD__4B0B45DD1A75C737");

                entity.ToTable("ChiTietDonHang");

                entity.Property(e => e.DiaChiNhanHang)
                      .HasMaxLength(255)
                      .IsRequired(false);

                entity.Property(e => e.lyDoHuyDon) // <-- cấu hình mới thêm
                      .HasMaxLength(500)           // độ dài tùy bạn muốn
                      .IsRequired(false);          // true nếu bắt buộc nhập

                entity.HasOne(d => d.MaComboNavigation).WithMany(p => p.ChiTietDonHangs)
                    .HasForeignKey(d => d.MaCombo)
                    .HasConstraintName("FK__ChiTietDo__MaCom__48CFD27E");

                entity.HasOne(d => d.MaDonHangNavigation).WithMany(p => p.ChiTietDonHangs)
                    .HasForeignKey(d => d.MaDonHang)
                    .HasConstraintName("FK__ChiTietDo__MaDon__46E78A0C");

                entity.HasOne(d => d.MaMonAnNavigation).WithMany(p => p.ChiTietDonHangs)
                    .HasForeignKey(d => d.MaMonAn)
                    .HasConstraintName("FK__ChiTietDo__MaMon__47DBAE45");
            });


            modelBuilder.Entity<Cartdetails>(entity =>
			{
				entity.HasKey(e => e.MaChiTietGioHang).HasName("PK__ChiTietG__BBF4749862250370");

				entity.ToTable("ChiTietGioHang");

				entity.Property(e => e.Loai).HasMaxLength(50);

				entity.HasOne(d => d.MaComboNavigation).WithMany(p => p.ChiTietGioHangs)
					.HasForeignKey(d => d.MaCombo)
					.HasConstraintName("FK__ChiTietGi__MaCom__5070F446");

				entity.HasOne(d => d.MaGioHangNavigation).WithMany(p => p.ChiTietGioHangs)
					.HasForeignKey(d => d.MaGioHang)
					.HasConstraintName("FK__ChiTietGi__MaGio__4E88ABD4");

				entity.HasOne(d => d.MaMonAnNavigation).WithMany(p => p.ChiTietGioHangs)
					.HasForeignKey(d => d.MaMonAn)
					.HasConstraintName("FK__ChiTietGi__MaMon__4F7CD00D");
			});

			modelBuilder.Entity<Combo>(entity =>
			{
				entity.HasKey(e => e.MaCombo).HasName("PK__Combo__C3EDBC780AF5616F");

				entity.ToTable("Combo");

				entity.Property(e => e.DuongDanHinh).HasMaxLength(255);
				entity.Property(e => e.MoTa).HasMaxLength(255);
				entity.Property(e => e.TenCombo).HasMaxLength(255);
			});

			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Order>(entity =>
			{
				entity.HasKey(e => e.MaDonHang);
				entity.Property(e => e.ThoiGianDat).HasColumnType("datetime");
				entity.Property(e => e.TrangThai).HasMaxLength(50);


				entity.HasOne(d => d.MaNguoiDungNavigation)
					  .WithMany(p => p.DonHangs)
					  .HasForeignKey(d => d.MaNguoiDung)
					  .HasConstraintName("FK_DonHang_User");
			});

			modelBuilder.Entity<ShoppingCart>(entity =>
			{
				entity.HasKey(e => e.MaGioHang);

				// Thay NguoiDung bằng ApplicationUser
				entity.HasOne(d => d.MaNguoiDungNavigation)
					  .WithMany(p => p.GioHangs)
					  .HasForeignKey(d => d.MaNguoiDung)
					  .HasConstraintName("FK_GioHang_User");
			});

			modelBuilder.Entity<Dish>(entity =>
			{
				entity.HasKey(e => e.MaMonAn).HasName("PK__MonAn__B1171625E776C924");

				entity.ToTable("MonAn");

				entity.Property(e => e.DuongDanHinh).HasMaxLength(255);
				entity.Property(e => e.MoTa).HasMaxLength(255);
				entity.Property(e => e.TenMonAn).HasMaxLength(255);

				entity.HasOne(d => d.MaTagNavigation).WithMany(p => p.MonAns)
					.HasForeignKey(d => d.MaTag)
					.HasConstraintName("FK__MonAn__MaTag__398D8EEE");
			});



			modelBuilder.Entity<Tag>(entity =>
			{
				entity.HasKey(e => e.MaTag).HasName("PK__Tag__314EC2148ECC02F7");

				entity.ToTable("Tag");

				entity.Property(e => e.TenTag).HasMaxLength(255);
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

	}
}
