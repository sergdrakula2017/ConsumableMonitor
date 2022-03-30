﻿// <auto-generated />
using System;
using ConsumableMonitor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConsumableMonitor.Data.Migrations
{
    [DbContext(typeof(ConsumableMonitorDataContext))]
    [Migration("20220330153636_MoneyInInventoryDefinitions")]
    partial class MoneyInInventoryDefinitions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ConsumableMonitor.Models.Consumable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Cost")
                        .HasColumnType("money");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("InstalledInEquipmentId")
                        .HasColumnType("integer");

                    b.Property<int>("InstalledInNumber")
                        .HasColumnType("integer");

                    b.Property<int>("ModelId")
                        .HasColumnType("integer");

                    b.Property<bool>("Scrapped")
                        .HasColumnType("boolean");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.HasIndex("SerialNumber");

                    b.HasIndex("InstalledInEquipmentId", "InstalledInNumber")
                        .IsUnique();

                    b.ToTable("Consumables");
                });

            modelBuilder.Entity("ConsumableMonitor.Models.ConsumableModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FamilyId")
                        .HasColumnType("integer");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasAlternateKey("Producer", "Model");

                    b.HasIndex("FamilyId");

                    b.HasIndex("Model");

                    b.HasIndex("Producer");

                    b.ToTable("ConsumableModels");
                });

            modelBuilder.Entity("ConsumableMonitor.Models.ConsumableModelFamily", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("ConsumableModelsFamilies");
                });

            modelBuilder.Entity("ConsumableMonitor.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Cost")
                        .HasColumnType("money");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ModelId")
                        .HasColumnType("integer");

                    b.Property<bool>("Scrapped")
                        .HasColumnType("boolean");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.HasIndex("SerialNumber");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("ConsumableMonitor.Models.EquipmentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasAlternateKey("Producer", "Model");

                    b.HasIndex("Model");

                    b.HasIndex("Producer");

                    b.ToTable("EquipmentModels");
                });

            modelBuilder.Entity("ConsumableMonitor.Models.EquipmentSlot", b =>
                {
                    b.Property<int>("EquipmentId")
                        .HasColumnType("integer");

                    b.Property<int>("SlotNumber")
                        .HasColumnType("integer");

                    b.Property<int>("InstalledId")
                        .HasColumnType("integer");

                    b.HasKey("EquipmentId", "SlotNumber");

                    b.HasIndex("EquipmentId");

                    b.ToTable("EquipmentSlots");
                });

            modelBuilder.Entity("ConsumableMonitor.Models.EquipmentSlotDescriptor", b =>
                {
                    b.Property<int>("ModelId")
                        .HasColumnType("integer");

                    b.Property<int>("SlotNumber")
                        .HasColumnType("integer");

                    b.Property<int>("ConsumableModelFamilyId")
                        .HasColumnType("integer");

                    b.Property<int?>("ConsumableModelId")
                        .HasColumnType("integer");

                    b.HasKey("ModelId", "SlotNumber");

                    b.HasIndex("ConsumableModelFamilyId");

                    b.HasIndex("ConsumableModelId");

                    b.HasIndex("ModelId");

                    b.ToTable("EquipmentSlotDescriptors");
                });

            modelBuilder.Entity("ConsumableMonitor.Models.Consumable", b =>
                {
                    b.HasOne("ConsumableMonitor.Models.ConsumableModel", "Model")
                        .WithMany("Consumables")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsumableMonitor.Models.EquipmentSlot", "InstalledIn")
                        .WithOne("Installed")
                        .HasForeignKey("ConsumableMonitor.Models.Consumable", "InstalledInEquipmentId", "InstalledInNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InstalledIn");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("ConsumableMonitor.Models.ConsumableModel", b =>
                {
                    b.HasOne("ConsumableMonitor.Models.ConsumableModelFamily", "Family")
                        .WithMany("Models")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Family");
                });

            modelBuilder.Entity("ConsumableMonitor.Models.Equipment", b =>
                {
                    b.HasOne("ConsumableMonitor.Models.EquipmentModel", "Model")
                        .WithMany("Equipments")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Model");
                });

            modelBuilder.Entity("ConsumableMonitor.Models.EquipmentSlot", b =>
                {
                    b.HasOne("ConsumableMonitor.Models.Equipment", "Equipment")
                        .WithMany("Slots")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");
                });

            modelBuilder.Entity("ConsumableMonitor.Models.EquipmentSlotDescriptor", b =>
                {
                    b.HasOne("ConsumableMonitor.Models.ConsumableModelFamily", "ConsumableModelFamily")
                        .WithMany("SlotDescriptors")
                        .HasForeignKey("ConsumableModelFamilyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsumableMonitor.Models.ConsumableModel", null)
                        .WithMany("SupportedSlotDescriptors")
                        .HasForeignKey("ConsumableModelId");

                    b.HasOne("ConsumableMonitor.Models.EquipmentModel", "EquipmentModel")
                        .WithMany("SlotDescriptors")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConsumableModelFamily");

                    b.Navigation("EquipmentModel");
                });

            modelBuilder.Entity("ConsumableMonitor.Models.ConsumableModel", b =>
                {
                    b.Navigation("Consumables");

                    b.Navigation("SupportedSlotDescriptors");
                });

            modelBuilder.Entity("ConsumableMonitor.Models.ConsumableModelFamily", b =>
                {
                    b.Navigation("Models");

                    b.Navigation("SlotDescriptors");
                });

            modelBuilder.Entity("ConsumableMonitor.Models.Equipment", b =>
                {
                    b.Navigation("Slots");
                });

            modelBuilder.Entity("ConsumableMonitor.Models.EquipmentModel", b =>
                {
                    b.Navigation("Equipments");

                    b.Navigation("SlotDescriptors");
                });

            modelBuilder.Entity("ConsumableMonitor.Models.EquipmentSlot", b =>
                {
                    b.Navigation("Installed");
                });
#pragma warning restore 612, 618
        }
    }
}
