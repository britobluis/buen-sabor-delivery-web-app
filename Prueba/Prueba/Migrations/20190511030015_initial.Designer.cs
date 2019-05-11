﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prueba.Models;

namespace Prueba.Migrations
{
    [DbContext(typeof(PruebaContext))]
    [Migration("20190511030015_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Prueba.Models.Devolucion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FacturaID");

                    b.Property<DateTime>("FechaDevolucion");

                    b.Property<string>("Motivo");

                    b.HasKey("ID");

                    b.HasIndex("FacturaID");

                    b.ToTable("Devolucion");
                });

            modelBuilder.Entity("Prueba.Models.Factura", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Fecha");

                    b.Property<double>("Monto");

                    b.HasKey("ID");

                    b.ToTable("Factura");
                });

            modelBuilder.Entity("Prueba.Models.Devolucion", b =>
                {
                    b.HasOne("Prueba.Models.Factura", "Factura")
                        .WithMany("Devolucions")
                        .HasForeignKey("FacturaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
