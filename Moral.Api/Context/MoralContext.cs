using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Entities;
using IdentityServer4.EntityFramework.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Moral.Api.Entities;

namespace Moral.Api.Context
{
    public class MoralContext : IdentityDbContext<Account>
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<MoralComment> MoralComments { get; set; }
        public DbSet<MoralTag> MoralTags { get; set; }
        public DbSet<PersonTag> PersonTags { get; set; }
        public DbSet<Request> Requests { get; set; }

        public MoralContext(DbContextOptions<MoralContext> options)
            : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlite("Data Source=moral.db");
        protected override void OnModelCreating( ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MoralComment>()
                .HasOne(m => m.By)
                .WithMany(t => t.SentMoralComments)
                .HasForeignKey(m => m.ById).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MoralComment>()
                .HasOne(m => m.For)
                .WithMany(t => t.InBoxMoralComments)
                .HasForeignKey(m => m.ById).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Request>()
                .HasOne(m => m.By)
                .WithMany(t => t.IncomingRequests)
                .HasForeignKey(m => m.ById).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Request>()
                .HasOne(m => m.For)
                .WithMany(t => t.OutcomingRequests)
                .HasForeignKey(m => m.ById).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PersonTag>()
                .HasOne(m => m.By)
                .WithMany(t => t.InTags)
                .HasForeignKey(m => m.ById).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PersonTag>()
                .HasOne(m => m.For)
                .WithMany(t => t.OutTags)
                .HasForeignKey(m => m.ById).OnDelete(DeleteBehavior.NoAction);
        }

    }
}
