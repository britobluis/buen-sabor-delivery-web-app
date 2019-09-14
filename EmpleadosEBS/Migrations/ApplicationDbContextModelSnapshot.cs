﻿// <auto-generated />
using System;
using EmpleadosEBS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmpleadosEBS.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmpleadosEBS.Models.Articulo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aprobado");

                    b.Property<string>("Denominacion")
                        .IsRequired();

                    b.Property<bool>("EsInsumo");

                    b.Property<double>("PrecioCompra");

                    b.Property<double>("PrecioVenta");

                    b.Property<double>("Stock");

                    b.Property<string>("UnidadMedida");

                    b.HasKey("ID");

                    b.ToTable("Articulo");
                });

            modelBuilder.Entity("EmpleadosEBS.Models.DetPedido", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArticuloID");

                    b.Property<int>("Cantidad");

                    b.Property<int?>("PedidoID");

                    b.Property<int?>("PlatoID");

                    b.Property<double>("PrecioArticulo");

                    b.Property<double>("PrecioPlato");

                    b.HasKey("ID");

                    b.HasIndex("ArticuloID");

                    b.HasIndex("PedidoID");

                    b.HasIndex("PlatoID");

                    b.ToTable("DetPedido");
                });

            modelBuilder.Entity("EmpleadosEBS.Models.EstadoPedido", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Denominacion");

                    b.Property<string>("Descripcion")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("EstadoPedido");
                });

            modelBuilder.Entity("EmpleadosEBS.Models.Pedido", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EstadoPedidoID");

                    b.Property<bool>("Facturado");

                    b.Property<DateTime>("FechaHora");

                    b.Property<int>("NumeroPedido");

                    b.Property<bool>("PorDelivery");

                    b.Property<double>("PrecioVenta");

                    b.HasKey("ID");

                    b.HasIndex("EstadoPedidoID");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("EmpleadosEBS.Models.Plato", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aprobado");

                    b.Property<string>("Denominacion")
                        .IsRequired();

                    b.Property<string>("Descripcion");

                    b.Property<string>("Imagen");

                    b.Property<double>("PrecioVenta");

                    b.HasKey("ID");

                    b.ToTable("Plato");
                });

            modelBuilder.Entity("EmpleadosEBS.Models.Receta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArticuloID");

                    b.Property<double>("Cantidad");

                    b.Property<int>("PlatoID");

                    b.HasKey("ID");

                    b.HasIndex("ArticuloID");

                    b.HasIndex("PlatoID");

                    b.ToTable("Receta");
                });

            modelBuilder.Entity("EmpleadosEBS.Models.ShoppingCartItem", b =>
                {
                    b.Property<int>("ShoppingCartItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ArticuloID");

                    b.Property<int>("Cantidad");

                    b.Property<int?>("PlatoID");

                    b.Property<string>("ShoppingCartId");

                    b.HasKey("ShoppingCartItemId");

                    b.HasIndex("ArticuloID");

                    b.HasIndex("PlatoID");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("EmpleadosEBS.Models.DetPedido", b =>
                {
                    b.HasOne("EmpleadosEBS.Models.Articulo", "Articulo")
                        .WithMany("DetPedidos")
                        .HasForeignKey("ArticuloID");

                    b.HasOne("EmpleadosEBS.Models.Pedido", "Pedido")
                        .WithMany("DetPedidos")
                        .HasForeignKey("PedidoID");

                    b.HasOne("EmpleadosEBS.Models.Plato", "Plato")
                        .WithMany("DetPedidos")
                        .HasForeignKey("PlatoID");
                });

            modelBuilder.Entity("EmpleadosEBS.Models.Pedido", b =>
                {
                    b.HasOne("EmpleadosEBS.Models.EstadoPedido", "EstadoPedido")
                        .WithMany("Pedido")
                        .HasForeignKey("EstadoPedidoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EmpleadosEBS.Models.Receta", b =>
                {
                    b.HasOne("EmpleadosEBS.Models.Articulo", "Articulo")
                        .WithMany("Recetas")
                        .HasForeignKey("ArticuloID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EmpleadosEBS.Models.Plato", "Plato")
                        .WithMany("Recetas")
                        .HasForeignKey("PlatoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EmpleadosEBS.Models.ShoppingCartItem", b =>
                {
                    b.HasOne("EmpleadosEBS.Models.Articulo", "Articulo")
                        .WithMany()
                        .HasForeignKey("ArticuloID");

                    b.HasOne("EmpleadosEBS.Models.Plato", "Plato")
                        .WithMany()
                        .HasForeignKey("PlatoID");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
