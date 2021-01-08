using Microsoft.EntityFrameworkCore;
using Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class FilesServices : IFileRepository, ICrudRepository<Files>, IDisposable
    {
        #region :: Depenedency::

        private readonly FileContext _db;

        public FilesServices(FileContext db)
        {
            _db = db;
        }

        #endregion

        public async Task<bool> DeleteAsync(Files tModel)
        {
            return await Task.Run(() =>
            {
                try
                {
                    _db.Files.Remove(tModel);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> DeleteAsync(object Id)
        {
            return await Task.Run(async () => await DeleteAsync(GetByIdAsync(Id)));
        }

        public async void Dispose()
        {
            await _db.DisposeAsync();
        }

        public async Task<IEnumerable<Files>> GetAllAsync()
        {
            return await Task.Run(async () => await _db.Files.ToListAsync());
        }

        public async Task<IEnumerable<Files>> GetAllAsync(Expression<Func<Files, bool>> where)
        {
            return await Task.Run(async () => await _db.Files.Where(where).ToListAsync());
        }

        public async Task<Files> GetByIdAsync(object Id)
        {
            return await Task.Run(async () => await _db.Files.FindAsync(Id));
        }

        public async Task<IEnumerable<Files>> GetBySearchAsync(string q)
        {
            return await Task.Run(async () => await GetAllAsync(f => f.FileName.Contains(q)));
        }

        public async Task<Files> GetFileByDownloadLinkAsync(string downloadLink)
        {
            return await Task.Run(async () => await _db.Files.FirstOrDefaultAsync(f => f.DownloadLink == downloadLink));
        }

        public async Task<bool> InsertAsync(Files tModel)
        {
            return await Task.Run(async () =>
            {
                try
                {
                    await _db.Files.AddAsync(tModel);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public bool Save()
        {
            try
            {
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> SaveAsync()
        {
            return await Task.Run(async () =>
            {
                try
                {
                    await _db.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> UpdateAsync(Files tModel)
        {
            return await Task.Run( () =>
            {
                try
                {
                    _db.Files.Update(tModel);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }
    }
}
