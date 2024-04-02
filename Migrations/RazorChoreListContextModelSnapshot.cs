﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RazorChoreList.Data;

#nullable disable

namespace RazorChoreList.Migrations
{
    [DbContext(typeof(RazorChoreListContext))]
    partial class RazorChoreListContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("Chore", b =>
                {
                    b.Property<int>("ChoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ChoreName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CompletionStatus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PersonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ChoreId");

                    b.HasIndex("PersonId");

                    b.ToTable("Chore");
                });

            modelBuilder.Entity("Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChoreId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PersonId");

                    b.HasIndex("ChoreId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Chore", b =>
                {
                    b.HasOne("Person", "person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("person");
                });

            modelBuilder.Entity("Person", b =>
                {
                    b.HasOne("Chore", null)
                        .WithMany("People")
                        .HasForeignKey("ChoreId");
                });

            modelBuilder.Entity("Chore", b =>
                {
                    b.Navigation("People");
                });
#pragma warning restore 612, 618
        }
    }
}
