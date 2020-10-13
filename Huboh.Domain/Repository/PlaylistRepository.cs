using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Huboh.Domain.Services;
using Huboh.EntityFramework.Models;

namespace Huboh.Domain.Repository
{
    public class PlaylistRepository : IDataRepository<playlist>, IDisposable
    {
        //DBContext
        private readonly DBEntities _context = new DBEntities();

        public async Task<IEnumerable<playlist>> GetAll()
        {
            return await _context.playlist.ToListAsync();
        }

        public async Task<playlist> GetByID(int id)
        {
            return await _context.playlist.FindAsync(id);
        }

        public async Task<bool> Insert(playlist entity)
        {
            return await Task.Run(() => {
                try
                {
                    _context.playlist.Add(entity);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> Update(int id, playlist entity)
        {
            return await Task.Run(() => {
                try
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> Delete(int id)
        {
            return await Task.Run(() => {
                try
                {
                    playlist song_ = _context.playlist.Find(id);
                    _context.playlist.Remove(song_);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> Save()
        {
            return await Task.Run(() => {
                try
                {
                    _context.SaveChangesAsync();
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
