using Microsoft.EntityFrameworkCore;
using RealEstateWebSiteProjects.Core.Entities;
using RealEstateWebSiteProjects.Data;
using RealEstateWebSiteProjects.Service.IUnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateWebSiteProjects.Service.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContexts _dbContext;
        private bool disposed;

        public UnitOfWork(AppDbContexts dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CommitAsync()
        {

            bool returnValue = true;
            using (var dbContextTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    //yeni kayıt(lar) atılırken; recordDate şuanki tarih atılıyor
                    var addedEntities = _dbContext.ChangeTracker.Entries().Where(e => e.State == EntityState.Added).ToList();

                    addedEntities.ForEach(E =>
                    {
                        E.Property(nameof(BaseEntity.RecordDate)).CurrentValue = DateTime.Now;
                    });

                    //güncelleme yapılan kayıt(lar)'da; updateDate kolonuna suanki tarih verisi atılıyor
                    var editedEntities =
                        _dbContext.ChangeTracker.Entries().Where(e => e.State == EntityState.Modified).ToList();

                    editedEntities.ForEach(e =>
                    {
                        e.Property(nameof(BaseEntity.UpdateDate)).CurrentValue = DateTime.Now;
                    });

                    await _dbContext.SaveChangesAsync();

                    await dbContextTransaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    var hata = ex;
                    //Log Exception Handling message                      
                    returnValue = false;
                    await dbContextTransaction.RollbackAsync();
                }
            }

            return returnValue;

        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            disposed = true;
        }
    }
}
