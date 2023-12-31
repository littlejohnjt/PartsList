﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PartsList.Server.Data;

#nullable disable

namespace PartsList.Server.Migrations
{
    [DbContext(typeof(PartsListContext))]
    partial class PartsListContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PartVendor", b =>
                {
                    b.Property<int>("PartsId")
                        .HasColumnType("int");

                    b.Property<int>("VendorsId")
                        .HasColumnType("int");

                    b.HasKey("PartsId", "VendorsId");

                    b.HasIndex("VendorsId");

                    b.ToTable("PartVendor");
                });

            modelBuilder.Entity("PartsList.Shared.Models.AssemblyConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Version")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AssemblyConfiguration", (string)null);
                });

            modelBuilder.Entity("PartsList.Shared.Models.AssemblyItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AssemblyConfigurationId")
                        .HasColumnType("int");

                    b.Property<int?>("PartId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssemblyConfigurationId");

                    b.HasIndex("PartId");

                    b.ToTable("AssemblyItem", (string)null);
                });

            modelBuilder.Entity("PartsList.Shared.Models.ComponentAssembly", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CageCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Version")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ComponentAssembly", (string)null);
                });

            modelBuilder.Entity("PartsList.Shared.Models.InventoryItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ComponentAssemblyId")
                        .HasColumnType("int");

                    b.Property<int?>("PartId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ComponentAssemblyId");

                    b.HasIndex("PartId");

                    b.ToTable("InventoryItem", (string)null);
                });

            modelBuilder.Entity("PartsList.Shared.Models.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ISReplacementForPartId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDiscontinued")
                        .HasColumnType("bit");

                    b.Property<int?>("IsReplacementForId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nomenclature")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizationId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PartUri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefDes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Units")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IsReplacementForId");

                    b.ToTable("Part", (string)null);
                });

            modelBuilder.Entity("PartsList.Shared.Models.PurchaseLineItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AssociatedPurchaseOrderId")
                        .HasColumnType("int");

                    b.Property<int>("PartId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal?>("Tax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AssociatedPurchaseOrderId");

                    b.HasIndex("PartId");

                    b.ToTable("PurchaseLineItem", (string)null);
                });

            modelBuilder.Entity("PartsList.Shared.Models.PurchaseOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("ShippingCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("VendorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VendorId");

                    b.ToTable("PurchaseOrder", (string)null);
                });

            modelBuilder.Entity("PartsList.Shared.Models.Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CageCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PocName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vendor", (string)null);
                });

            modelBuilder.Entity("PartVendor", b =>
                {
                    b.HasOne("PartsList.Shared.Models.Part", null)
                        .WithMany()
                        .HasForeignKey("PartsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PartsList.Shared.Models.Vendor", null)
                        .WithMany()
                        .HasForeignKey("VendorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PartsList.Shared.Models.AssemblyItem", b =>
                {
                    b.HasOne("PartsList.Shared.Models.AssemblyConfiguration", "Configuration")
                        .WithMany("AssemblyItems")
                        .HasForeignKey("AssemblyConfigurationId");

                    b.HasOne("PartsList.Shared.Models.Part", "Part")
                        .WithMany()
                        .HasForeignKey("PartId");

                    b.Navigation("Configuration");

                    b.Navigation("Part");
                });

            modelBuilder.Entity("PartsList.Shared.Models.InventoryItem", b =>
                {
                    b.HasOne("PartsList.Shared.Models.ComponentAssembly", "ComponentAssembly")
                        .WithMany("Items")
                        .HasForeignKey("ComponentAssemblyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PartsList.Shared.Models.Part", "Part")
                        .WithMany()
                        .HasForeignKey("PartId");

                    b.Navigation("ComponentAssembly");

                    b.Navigation("Part");
                });

            modelBuilder.Entity("PartsList.Shared.Models.Part", b =>
                {
                    b.HasOne("PartsList.Shared.Models.Part", "IsReplacementFor")
                        .WithMany()
                        .HasForeignKey("IsReplacementForId");

                    b.Navigation("IsReplacementFor");
                });

            modelBuilder.Entity("PartsList.Shared.Models.PurchaseLineItem", b =>
                {
                    b.HasOne("PartsList.Shared.Models.PurchaseOrder", "AssociatedPurchaseOrder")
                        .WithMany("LineItems")
                        .HasForeignKey("AssociatedPurchaseOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PartsList.Shared.Models.Part", "Part")
                        .WithMany()
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssociatedPurchaseOrder");

                    b.Navigation("Part");
                });

            modelBuilder.Entity("PartsList.Shared.Models.PurchaseOrder", b =>
                {
                    b.HasOne("PartsList.Shared.Models.Vendor", "Vendor")
                        .WithMany()
                        .HasForeignKey("VendorId");

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("PartsList.Shared.Models.AssemblyConfiguration", b =>
                {
                    b.Navigation("AssemblyItems");
                });

            modelBuilder.Entity("PartsList.Shared.Models.ComponentAssembly", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("PartsList.Shared.Models.PurchaseOrder", b =>
                {
                    b.Navigation("LineItems");
                });
#pragma warning restore 612, 618
        }
    }
}
