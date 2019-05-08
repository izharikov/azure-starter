using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Starter.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Azure.Starter.Database.Context
{
    public abstract class TrackableDbContext : DbContext
    {
        protected TrackableDbContext()
        {
        }

        protected TrackableDbContext(DbContextOptions options) : base(options)
        {
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is ITrackable trackable)
                {
                    var now = DateTime.Now;
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            trackable.LastUpdated = now;
                            break;

                        case EntityState.Added:
                            trackable.Created = now;
                            trackable.LastUpdated = now;
                            break;
                    }
                }
            }
        }
    }
}