using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Starter.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Azure.Starter.Database.Context
{
    public class SampleAppContext : TrackableDbContext
    {
        public SampleAppContext()
        {
        }

        public SampleAppContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SampleModel> Samples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SampleModel>()
                .Property(e => e.Features)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
            modelBuilder.Entity<SampleModel>().HasData(new SampleModel
            {
                Id = Guid.Parse("307FE9C6-FB15-4E3E-A3D3-494339348380"),
                Created = DateTime.Now,
                LastUpdated = DateTime.Now,
                Description = "[Description]",
                Name = "[Name]",
                DisplayName = "[DisplayName]",
                Features = new List<string>()
                {
                    "Feature #1",
                    "Feature #2",
                    "Feature #3",
                }
            });
        }
    }
}