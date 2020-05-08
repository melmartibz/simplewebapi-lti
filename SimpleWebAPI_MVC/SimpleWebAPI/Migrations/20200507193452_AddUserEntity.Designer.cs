﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleWebAPI.Data;

namespace SimpleWebAPI.Migrations
{
    [DbContext(typeof(MainDBContext))]
    [Migration("20200507193452_AddUserEntity")]
    partial class AddUserEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SimpleWebAPI.Models.Entities.Category", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            ID = new Guid("3b0954a1-1c83-43e6-b979-bb647d84c856"),
                            Name = "Kitchewares"
                        },
                        new
                        {
                            ID = new Guid("715ccf0c-5259-44e9-95ab-be0be18eeb7f"),
                            Name = "Gadgets and Electronics"
                        },
                        new
                        {
                            ID = new Guid("50fdd9e6-6ce9-43af-96c8-5813bc32ddf8"),
                            Name = "Gardening Tools"
                        },
                        new
                        {
                            ID = new Guid("6c8e2c04-b324-44bf-993f-4b62c434dce6"),
                            Name = "Sports Equipment"
                        },
                        new
                        {
                            ID = new Guid("96d31214-0c35-402b-ab35-4994ee27fea5"),
                            Name = "Gaming"
                        });
                });

            modelBuilder.Entity("SimpleWebAPI.Models.Entities.Product", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ID = new Guid("b0793b6c-9ea5-46bb-bd14-8d51f1a94c70"),
                            CategoryID = new Guid("96d31214-0c35-402b-ab35-4994ee27fea5"),
                            Description = "Final Fantasy 7 Remake",
                            Image = "https://gadgetpilipinas.net/wp-content/uploads/2019/09/ff7remake1st.jpg",
                            Name = "FF7 Remake"
                        });
                });

            modelBuilder.Entity("SimpleWebAPI.Models.Entities.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = new Guid("ae1c050f-ca33-49c4-8310-0255d3500397"),
                            Email = "user@useremail.com",
                            Password = "123password",
                            Username = "Weeddnim"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}