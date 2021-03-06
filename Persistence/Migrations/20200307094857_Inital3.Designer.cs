﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20200307094857_Inital3")]
    partial class Inital3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Phone");

                    b.Property<string>("Username");

                    b.Property<string>("email");

                    b.Property<string>("password");

                    b.HasKey("Id");

                    b.ToTable("administrators");
                });

            modelBuilder.Entity("Model.Commodity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CommoditycategoryId");

                    b.Property<string>("Commodityname");

                    b.Property<int>("Price");

                    b.Property<int>("UserId");

                    b.Property<int>("days");

                    b.Property<string>("expiredate");

                    b.Property<string>("startdate");

                    b.Property<bool>("status");

                    b.HasKey("Id");

                    b.ToTable("commodities");
                });

            modelBuilder.Entity("Model.CommodityCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Categoryname");

                    b.HasKey("Id");

                    b.ToTable("commodityCategories");
                });

            modelBuilder.Entity("Model.Customers", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int>("Age");

                    b.Property<string>("CustomerName");

                    b.Property<string>("Email");

                    b.Property<string>("Gender");

                    b.Property<string>("Idcard");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Model.OrderInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int>("Commodityid");

                    b.Property<string>("OrderUser");

                    b.Property<string>("Orderstringid");

                    b.Property<string>("Phone");

                    b.Property<string>("Startdatetime");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("orderInfos");
                });

            modelBuilder.Entity("Model.Salesrecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Categoryid");

                    b.Property<int>("Commdityid");

                    b.Property<string>("OrderUser");

                    b.Property<string>("Startdatetime");

                    b.Property<int>("Userid");

                    b.Property<bool>("isfinally");

                    b.HasKey("Id");

                    b.ToTable("salesrecords");
                });

            modelBuilder.Entity("Model.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Phone");

                    b.Property<string>("Username");

                    b.Property<string>("email");

                    b.Property<string>("password");

                    b.Property<int>("socre");

                    b.HasKey("Id");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}
