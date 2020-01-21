﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookStoreDAL.Migrations
{
    [DbContext(typeof(BookStoreContext))]
    partial class BookStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Shared.Models.AbstractDiscount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Percent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Discounts");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AbstractDiscount");
                });

            modelBuilder.Entity("Shared.Models.AbstractItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PrintDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.ToTable("Items");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AbstractItem");
                });

            modelBuilder.Entity("Shared.Models.AbstractItemGenre", b =>
                {
                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("ItemId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("ItemGenres");
                });

            modelBuilder.Entity("Shared.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PenName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Jon Doe",
                            PenName = "JD"
                        });
                });

            modelBuilder.Entity("Shared.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Comedy"
                        });
                });

            modelBuilder.Entity("Shared.Models.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ran Forrest"
                        });
                });

            modelBuilder.Entity("Shared.Models.DiscountByAuthor", b =>
                {
                    b.HasBaseType("Shared.Models.AbstractDiscount");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("DiscountByAuthor");
                });

            modelBuilder.Entity("Shared.Models.DiscountByGenre", b =>
                {
                    b.HasBaseType("Shared.Models.AbstractDiscount");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("DiscountByGenre");
                });

            modelBuilder.Entity("Shared.Models.DiscountByPublishDate", b =>
                {
                    b.HasBaseType("Shared.Models.AbstractDiscount");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("DiscountByPublishDate");
                });

            modelBuilder.Entity("Shared.Models.DiscountByPublisher", b =>
                {
                    b.HasBaseType("Shared.Models.AbstractDiscount");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("DiscountByPublisher");
                });

            modelBuilder.Entity("Shared.Models.Book", b =>
                {
                    b.HasBaseType("Shared.Models.AbstractItem");

                    b.Property<int>("AuthorFK")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("AuthorId");

                    b.HasDiscriminator().HasValue("Book");
                });

            modelBuilder.Entity("Shared.Models.Journal", b =>
                {
                    b.HasBaseType("Shared.Models.AbstractItem");

                    b.Property<int>("CopyNum")
                        .HasColumnType("int");

                    b.Property<string>("ISSN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Journal");
                });

            modelBuilder.Entity("Shared.Models.AbstractItem", b =>
                {
                    b.HasOne("Shared.Models.Publisher", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Shared.Models.AbstractItemGenre", b =>
                {
                    b.HasOne("Shared.Models.Genre", "Genre")
                        .WithMany("ItemGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shared.Models.AbstractItem", "Item")
                        .WithMany("ItemGenres")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Shared.Models.Book", b =>
                {
                    b.HasOne("Shared.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
