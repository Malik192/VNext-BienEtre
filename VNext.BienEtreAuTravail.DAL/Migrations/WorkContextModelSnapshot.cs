﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VNext.BienEtreAuTravail.DAL.Context;

namespace VNext.BienEtreAuTravail.DAL.Migrations
{
    [DbContext(typeof(WorkContext))]
    partial class WorkContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VNext.BienEtreAuTravail.DAL.Models.Database.Commentaire", b =>
                {
                    b.Property<int>("IdCommentaire")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("IdCommentaire");

                    b.ToTable("Commentaires");
                });

            modelBuilder.Entity("VNext.BienEtreAuTravail.DAL.Models.Database.CommentaireEmp", b =>
                {
                    b.Property<int>("IdEmployee")
                        .HasColumnType("int");

                    b.Property<int>("IdCommentaire")
                        .HasColumnType("int");

                    b.Property<int?>("CommentaireIdCommentaire")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeIdEmployee")
                        .HasColumnType("int");

                    b.HasKey("IdEmployee", "IdCommentaire");

                    b.HasIndex("CommentaireIdCommentaire");

                    b.HasIndex("EmployeeIdEmployee");

                    b.ToTable("CommentaireEmps");
                });

            modelBuilder.Entity("VNext.BienEtreAuTravail.DAL.Models.Database.Employee", b =>
                {
                    b.Property<int>("IdEmployee")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Pseudo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("IdEmployee");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("VNext.BienEtreAuTravail.DAL.Models.Database.CommentaireEmp", b =>
                {
                    b.HasOne("VNext.BienEtreAuTravail.DAL.Models.Database.Commentaire", "Commentaire")
                        .WithMany()
                        .HasForeignKey("CommentaireIdCommentaire");

                    b.HasOne("VNext.BienEtreAuTravail.DAL.Models.Database.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeIdEmployee");
                });
#pragma warning restore 612, 618
        }
    }
}
