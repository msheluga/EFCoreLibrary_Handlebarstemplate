﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EFCoreLibrary.Models;

namespace EFCoreLibrary.Data
{
    public partial class BooksContext : DbContext
    {
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<BooksInGroups> BooksInGroups { get; set; }
        public virtual DbSet<DeviceCodes> DeviceCodes { get; set; }
        public virtual DbSet<Fields> Fields { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Keys> Keys { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<PersistedGrants> PersistedGrants { get; set; }
        public virtual DbSet<Press> Press { get; set; }
        public virtual DbSet<Tables> Tables { get; set; }
        public virtual DbSet<UserAccessView> UserAccessView { get; set; }
        public virtual DbSet<UserFieldAccess> UserFieldAccess { get; set; }
        public virtual DbSet<UserTableAccess> UserTableAccess { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersInGroup> UsersInGroup { get; set; }

        public BooksContext(DbContextOptions<BooksContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book_Address");

                entity.HasOne(d => d.Press)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.PressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book_Press");
            });

            modelBuilder.Entity<BooksInGroups>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.GroupId });

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BooksInGroups)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BooksInGroups_Book");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.BooksInGroups)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BooksInGroups_Groups");
            });

            modelBuilder.Entity<Fields>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.Fields)
                    .HasForeignKey(d => d.TableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fields_Tables");
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Press>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Tables>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<UserAccessView>(entity =>
            {
                entity.ToView("UserAccessView");
            });

            modelBuilder.Entity<UserFieldAccess>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.UserFieldAccess)
                    .HasForeignKey(d => d.FieldId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserFieldAccess_Fields");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserFieldAccess)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserFieldAccess_Users");
            });

            modelBuilder.Entity<UserTableAccess>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.UserTableAccess)
                    .HasForeignKey(d => d.TableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserTableAccess_Tables");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTableAccess)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserTableAccess_Users");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<UsersInGroup>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.GroupId });

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.UsersInGroup)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersInGroup_Groups");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersInGroup)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersInGroup_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
