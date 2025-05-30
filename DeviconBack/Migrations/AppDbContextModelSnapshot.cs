﻿// <auto-generated />
using System;
using DeviconBack.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DeviconBack.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DeviconBack.Data.Entities.Valute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CharCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nominal")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ValuteCourseId")
                        .HasColumnType("int");

                    b.Property<decimal>("VunitRate")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ValuteCourseId");

                    b.ToTable("Valutes");
                });

            modelBuilder.Entity("DeviconBack.Data.Entities.ValuteCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ValuteCourses");
                });

            modelBuilder.Entity("DeviconBack.Data.Entities.Valute", b =>
                {
                    b.HasOne("DeviconBack.Data.Entities.ValuteCourse", "ValuteCourse")
                        .WithMany("Valutes")
                        .HasForeignKey("ValuteCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ValuteCourse");
                });

            modelBuilder.Entity("DeviconBack.Data.Entities.ValuteCourse", b =>
                {
                    b.Navigation("Valutes");
                });
#pragma warning restore 612, 618
        }
    }
}
