using Core.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Foundation;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Data.Common;
using Core.Logging;

namespace Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>, IDbContext
    {

        private ObjectContext _objectContext;
        private DbTransaction _transaction;
        private static readonly object Lock = new object();
        private static bool _databaseInitialized;

        public AppDbContext() : base("AppDbContext")
        {
        }

        public AppDbContext(string nameOrConnectionString, ILogger logger)
            : base(nameOrConnectionString)
        {
            if (logger != null)
            {
                Database.Log = logger.Log;
            }

            if (_databaseInitialized)
            {
                return;
            }
            lock (Lock)
            {
                if (!_databaseInitialized)
                {
                    Database.SetInitializer(new DBInitializer());
                    _databaseInitialized = true;
                }
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ContactConfiguration());
        }

        public static AppDbContext Create()
        {
            return new AppDbContext(nameOrConnectionString: "   AppDbConnection", logger: null);
        }

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public Task<int> CommitAsync()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public void SetAsAdded<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public void SetAsDeleted<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        public void SetAsModified<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }

        IDbSet<TEntity> IDbContext.Set<TEntity>()
        {
            throw new NotImplementedException();
        }


        private void UpdateEntityState<TEnity>(TEnity entity, EntityState entityState) where TEnity : BaseEntity
        {
            var dbEntityEntry = GetDbEntityEntrySafely<TEnity>(entity);
            dbEntityEntry.State = entityState;
        }

        private DbEntityEntry GetDbEntityEntrySafely<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            var dbEntityEntry = Entry<TEntity>(entity);

            if(dbEntityEntry.State == EntityState.Detached)
            {
                Set<TEntity>().Attach(entity);
            }

            return dbEntityEntry;
        }
    }
}
