// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apicds;

namespace apicds.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("apicds.Clientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaInscripcion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NroDeIdentificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TemaInteres")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("clientes");
                });

            modelBuilder.Entity("apicds.Models.Alquiler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaAlquiler")
                        .HasColumnType("datetime2");

                    b.Property<int>("ValorAlquiler")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("alquilers");
                });

            modelBuilder.Entity("apicds.Models.CD", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Condicion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("numCd")
                        .HasColumnType("int");

                    b.Property<string>("ubicacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("cd");
                });

            modelBuilder.Entity("apicds.Models.DetalleAlquiler", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlquilerId")
                        .HasColumnType("int");

                    b.Property<int>("CdId")
                        .HasColumnType("int");

                    b.Property<int>("DiasPrestamo")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaDevolucion")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AlquilerId");

                    b.HasIndex("CdId");

                    b.ToTable("detalleAlquilers");
                });

            modelBuilder.Entity("apicds.Models.Sancion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlquilerId")
                        .HasColumnType("int");

                    b.Property<int>("NroDiasSancion")
                        .HasColumnType("int");

                    b.Property<string>("TipoSancion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlquilerId");

                    b.ToTable("sancions");
                });

            modelBuilder.Entity("apicds.Models.Alquiler", b =>
                {
                    b.HasOne("apicds.Clientes", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("apicds.Models.DetalleAlquiler", b =>
                {
                    b.HasOne("apicds.Models.Alquiler", "Alquiler")
                        .WithMany()
                        .HasForeignKey("AlquilerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apicds.Models.CD", "CD")
                        .WithMany()
                        .HasForeignKey("CdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alquiler");

                    b.Navigation("CD");
                });

            modelBuilder.Entity("apicds.Models.Sancion", b =>
                {
                    b.HasOne("apicds.Models.Alquiler", "Alquiler")
                        .WithMany()
                        .HasForeignKey("AlquilerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alquiler");
                });
#pragma warning restore 612, 618
        }
    }
}
