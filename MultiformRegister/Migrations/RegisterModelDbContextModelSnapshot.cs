﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultiformRegister.DataModel;

#nullable disable

namespace MultiformRegister.Migrations
{
    [DbContext(typeof(RegisterModelDbContext))]
    partial class RegisterModelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MultiformRegister.DataModel.EducationDataModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<double>("Average")
                        .HasColumnType("float");

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.Property<long>("PersonDataModelId")
                        .HasColumnType("bigint");

                    b.Property<string>("UniversityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonDataModelId")
                        .IsUnique();

                    b.ToTable("Education");
                });

            modelBuilder.Entity("MultiformRegister.DataModel.PersonDataModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("MultiformRegister.DataModel.EducationDataModel", b =>
                {
                    b.HasOne("MultiformRegister.DataModel.PersonDataModel", null)
                        .WithOne("EducationDataModel")
                        .HasForeignKey("MultiformRegister.DataModel.EducationDataModel", "PersonDataModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MultiformRegister.DataModel.PersonDataModel", b =>
                {
                    b.Navigation("EducationDataModel")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
