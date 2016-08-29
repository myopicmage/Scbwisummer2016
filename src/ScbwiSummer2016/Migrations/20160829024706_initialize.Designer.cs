using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ScbwiSummer2016.Models;

namespace ScbwiSummer2016.Migrations
{
    [DbContext(typeof(ScbwiContext))]
    [Migration("20160829024706_initialize")]
    partial class initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("ScbwiSummer2016.Models.Location", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("description");

                    b.Property<string>("name");

                    b.Property<string>("speakers");

                    b.Property<string>("title");

                    b.HasKey("id");

                    b.ToTable("locations");
                });

            modelBuilder.Entity("ScbwiSummer2016.Models.Registration", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("address1");

                    b.Property<string>("address2");

                    b.Property<string>("city");

                    b.Property<DateTime>("cleared");

                    b.Property<string>("codeused");

                    b.Property<DateTime>("created");

                    b.Property<string>("email");

                    b.Property<string>("firstname");

                    b.Property<string>("lastname");

                    b.Property<int?>("locationid");

                    b.Property<bool>("member");

                    b.Property<DateTime>("paid");

                    b.Property<string>("phone");

                    b.Property<string>("state");

                    b.Property<decimal>("subtotal");

                    b.Property<decimal>("total");

                    b.Property<string>("zip");

                    b.HasKey("id");

                    b.HasIndex("locationid");

                    b.ToTable("registrations");
                });

            modelBuilder.Entity("ScbwiSummer2016.Models.Registration", b =>
                {
                    b.HasOne("ScbwiSummer2016.Models.Location", "location")
                        .WithMany()
                        .HasForeignKey("locationid");
                });
        }
    }
}
