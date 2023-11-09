﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoxessWebbus.Web.Migrations
{
    [DbContext(typeof(SqliteContext))]
    partial class SqliteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.12");

            modelBuilder.Entity("FoxessWebbus.Web.Data.ErrorLog", b =>
                {
                    b.Property<Guid>("ErrorLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ErrorDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ErrorLogId");

                    b.ToTable("ErrorLog");
                });

            modelBuilder.Entity("FoxessWebbus.Web.Data.H1ModelDb", b =>
                {
                    b.Property<Guid>("EntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<short>("BatteryCharge")
                        .HasColumnType("INTEGER");

                    b.Property<short>("BatteryDischarge")
                        .HasColumnType("INTEGER");

                    b.Property<short>("BatterySoc")
                        .HasColumnType("INTEGER");

                    b.Property<short>("BatteryTemp")
                        .HasColumnType("INTEGER");

                    b.Property<short>("FeedIn")
                        .HasColumnType("INTEGER");

                    b.Property<short>("FromGrid")
                        .HasColumnType("INTEGER");

                    b.Property<short>("InverterTemp")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LoggedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<short>("PVPower1")
                        .HasColumnType("INTEGER");

                    b.Property<short>("PVPower2")
                        .HasColumnType("INTEGER");

                    b.Property<short>("PVPowerTotal")
                        .HasColumnType("INTEGER");

                    b.HasKey("EntryId");

                    b.ToTable("FoxH1");
                });
#pragma warning restore 612, 618
        }
    }
}
