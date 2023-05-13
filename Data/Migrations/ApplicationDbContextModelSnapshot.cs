﻿// <auto-generated />
using System;
using LaptopShop_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LaptopShop_API.Models.Bill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DiaChiKhachHang")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("DiaChiKhachHang");

                    b.Property<string>("HoTenKhachHang")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("HoTenKhachHang");

                    b.Property<string>("Ma")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Ma");

                    b.Property<string>("SdtKhachHang")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("SoDienThoaiKhachHang");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VoucherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VoucherId");

                    b.ToTable("Bill", (string)null);
                });

            modelBuilder.Entity("LaptopShop_API.Models.BillDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdBill")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdProductDetails")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdBill");

                    b.HasIndex("IdProductDetails");

                    b.ToTable("BillDetail", (string)null);
                });

            modelBuilder.Entity("LaptopShop_API.Models.CardVGA", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ma")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Ten");

                    b.Property<string>("ThongSo")
                        .IsRequired()
                        .HasColumnType("varchar(70)")
                        .HasColumnName("ThongSo");

                    b.HasKey("Id");

                    b.ToTable("CardVGA", (string)null);
                });

            modelBuilder.Entity("LaptopShop_API.Models.Cart", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId");

                    b.ToTable("Cart", (string)null);
                });

            modelBuilder.Entity("LaptopShop_API.Models.CartDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdProductDetails")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IdProductDetails");

                    b.HasIndex("UserId");

                    b.ToTable("CartDetail", (string)null);
                });

            modelBuilder.Entity("LaptopShop_API.Models.Color", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ma")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(70)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Color", (string)null);
                });

            modelBuilder.Entity("LaptopShop_API.Models.Cpu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ma")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(70)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("CPU", (string)null);
                });

            modelBuilder.Entity("LaptopShop_API.Models.HardDrive", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ma")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoKheCam")
                        .HasColumnType("int");

                    b.Property<string>("ThongSo")
                        .IsRequired()
                        .HasColumnType("varchar(70)")
                        .HasColumnName("ThongSo");

                    b.HasKey("Id");

                    b.ToTable("SSD", (string)null);
                });

            modelBuilder.Entity("LaptopShop_API.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdProductDetail")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LinkImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("HinhAnh");

                    b.Property<string>("Ma")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Ma");

                    b.HasKey("Id");

                    b.HasIndex("IdProductDetail");

                    b.ToTable("Image", (string)null);
                });

            modelBuilder.Entity("LaptopShop_API.Models.Manufacturer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Manufacturer", (string)null);
                });

            modelBuilder.Entity("LaptopShop_API.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDManufacturer")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IDManufacturer");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("LaptopShop_API.Models.ProductDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<Guid?>("CardVGAId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("IdColor")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdCpu")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdHardDrive")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdProduct")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdRam")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ImportPrice")
                        .HasColumnType("decimal");

                    b.Property<string>("Ma")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal");

                    b.Property<Guid?>("ScreenId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CardVGAId");

                    b.HasIndex("IdColor");

                    b.HasIndex("IdCpu");

                    b.HasIndex("IdHardDrive");

                    b.HasIndex("IdProduct");

                    b.HasIndex("IdRam");

                    b.HasIndex("ScreenId");

                    b.ToTable("ProductDetail", (string)null);
                });

            modelBuilder.Entity("LaptopShop_API.Models.Ram", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ma")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("MoTa");

                    b.Property<int>("SoKheCam")
                        .HasColumnType("int");

                    b.Property<string>("ThongSo")
                        .IsRequired()
                        .HasColumnType("varchar(70)")
                        .HasColumnName("ThongSo");

                    b.HasKey("Id");

                    b.ToTable("RAM", (string)null);
                });

            modelBuilder.Entity("LaptopShop_API.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("LaptopShop_API.Models.Screen", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ChatLieu")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("ChatLieu");

                    b.Property<string>("KichCo")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("KichCo");

                    b.Property<string>("Ma")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TanSo")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("TanSo");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Ten");

                    b.HasKey("Id");

                    b.ToTable("Screen", (string)null);
                });

            modelBuilder.Entity("LaptopShop_API.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdRole")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Username");

                    b.HasIndex("IdRole");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("LaptopShop_API.Models.Voucher", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDay")
                        .HasColumnType("datetime")
                        .HasColumnName("EndDay");

                    b.Property<decimal>("GiaTri")
                        .HasColumnType("money")
                        .HasColumnName("GiaTri");

                    b.Property<string>("Ma")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Ma");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int")
                        .HasColumnName("SoLuong");

                    b.Property<DateTime>("StartDay")
                        .HasColumnType("datetime")
                        .HasColumnName("StarDay");

                    b.HasKey("ID");

                    b.ToTable("Voucher", (string)null);
                });

            modelBuilder.Entity("LaptopShop_API.Models.Bill", b =>
                {
                    b.HasOne("LaptopShop_API.Models.User", "User")
                        .WithMany("Bills")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaptopShop_API.Models.Voucher", "Voucher")
                        .WithMany("Bills")
                        .HasForeignKey("VoucherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Voucher");
                });

            modelBuilder.Entity("LaptopShop_API.Models.BillDetail", b =>
                {
                    b.HasOne("LaptopShop_API.Models.Bill", "Bill")
                        .WithMany("BillDetails")
                        .HasForeignKey("IdBill")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Bill");

                    b.HasOne("LaptopShop_API.Models.ProductDetail", "ProductDetail")
                        .WithMany("BillDetails")
                        .HasForeignKey("IdProductDetails")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ProductDetails");

                    b.Navigation("Bill");

                    b.Navigation("ProductDetail");
                });

            modelBuilder.Entity("LaptopShop_API.Models.Cart", b =>
                {
                    b.HasOne("LaptopShop_API.Models.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("LaptopShop_API.Models.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LaptopShop_API.Models.CartDetail", b =>
                {
                    b.HasOne("LaptopShop_API.Models.ProductDetail", "ProductDetail")
                        .WithMany("CartDetails")
                        .HasForeignKey("IdProductDetails")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaptopShop_API.Models.Cart", "Cart")
                        .WithMany("CartDetails")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("ProductDetail");
                });

            modelBuilder.Entity("LaptopShop_API.Models.Image", b =>
                {
                    b.HasOne("LaptopShop_API.Models.ProductDetail", "ProductDetail")
                        .WithMany("Imagess")
                        .HasForeignKey("IdProductDetail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductDetail");
                });

            modelBuilder.Entity("LaptopShop_API.Models.Product", b =>
                {
                    b.HasOne("LaptopShop_API.Models.Manufacturer", "Manufacturer")
                        .WithMany("Products")
                        .HasForeignKey("IDManufacturer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Manufacturer");

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("LaptopShop_API.Models.ProductDetail", b =>
                {
                    b.HasOne("LaptopShop_API.Models.CardVGA", null)
                        .WithMany("ProductDetails")
                        .HasForeignKey("CardVGAId");

                    b.HasOne("LaptopShop_API.Models.Color", "Color")
                        .WithMany("ProductDetails")
                        .HasForeignKey("IdColor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaptopShop_API.Models.Cpu", "Cpu")
                        .WithMany("ProductDetails")
                        .HasForeignKey("IdCpu")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaptopShop_API.Models.HardDrive", "HardDrive")
                        .WithMany("ProductDetails")
                        .HasForeignKey("IdHardDrive")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaptopShop_API.Models.Product", "Product")
                        .WithMany("ProductDetails")
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaptopShop_API.Models.Ram", "Ram")
                        .WithMany("ProductDetails")
                        .HasForeignKey("IdRam")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaptopShop_API.Models.Screen", null)
                        .WithMany("ProductDetails")
                        .HasForeignKey("ScreenId");

                    b.Navigation("Color");

                    b.Navigation("Cpu");

                    b.Navigation("HardDrive");

                    b.Navigation("Product");

                    b.Navigation("Ram");
                });

            modelBuilder.Entity("LaptopShop_API.Models.User", b =>
                {
                    b.HasOne("LaptopShop_API.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("IdRole")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("LaptopShop_API.Models.Bill", b =>
                {
                    b.Navigation("BillDetails");
                });

            modelBuilder.Entity("LaptopShop_API.Models.CardVGA", b =>
                {
                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("LaptopShop_API.Models.Cart", b =>
                {
                    b.Navigation("CartDetails");
                });

            modelBuilder.Entity("LaptopShop_API.Models.Color", b =>
                {
                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("LaptopShop_API.Models.Cpu", b =>
                {
                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("LaptopShop_API.Models.HardDrive", b =>
                {
                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("LaptopShop_API.Models.Manufacturer", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("LaptopShop_API.Models.Product", b =>
                {
                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("LaptopShop_API.Models.ProductDetail", b =>
                {
                    b.Navigation("BillDetails");

                    b.Navigation("CartDetails");

                    b.Navigation("Imagess");
                });

            modelBuilder.Entity("LaptopShop_API.Models.Ram", b =>
                {
                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("LaptopShop_API.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("LaptopShop_API.Models.Screen", b =>
                {
                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("LaptopShop_API.Models.User", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Cart")
                        .IsRequired();
                });

            modelBuilder.Entity("LaptopShop_API.Models.Voucher", b =>
                {
                    b.Navigation("Bills");
                });
#pragma warning restore 612, 618
        }
    }
}
