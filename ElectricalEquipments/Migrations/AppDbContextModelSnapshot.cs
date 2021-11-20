﻿// <auto-generated />
using System;
using ElectricalEquipments.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ElectricalEquipments.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ElectricalEquipments.Models.Motor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Rpm")
                        .HasColumnType("int");

                    b.Property<int?>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.ToTable("Motors");
                });

            modelBuilder.Entity("ElectricalEquipments.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodeName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("Id");

                    b.ToTable("Units");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CodeName = "DF1",
                            Name = "Döner Fırın 1"
                        },
                        new
                        {
                            Id = 2,
                            CodeName = "DF2",
                            Name = "Döner Fırın 2"
                        },
                        new
                        {
                            Id = 3,
                            CodeName = "ÇD1",
                            Name = "Çimento Değirmeni 1"
                        });
                });

            modelBuilder.Entity("ElectricalEquipments.Models.Motor", b =>
                {
                    b.HasOne("ElectricalEquipments.Models.Unit", null)
                        .WithMany("Motors")
                        .HasForeignKey("UnitId");
                });

            modelBuilder.Entity("ElectricalEquipments.Models.Unit", b =>
                {
                    b.Navigation("Motors");
                });
#pragma warning restore 612, 618
        }
    }
}
