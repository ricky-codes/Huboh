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
    public class SongRepository : IDataRepository<song> , IDisposable
    {
        //DBContext
        private readonly DBEntities _context = new DBEntities();

        public async Task<IEnumerable<song>> GetAll()
        {
            return await _context.song.ToListAsync();
        }

        public async Task<song> GetByID(int id)
        {
            return await _context.song.FindAsync(id);
        }

        public async Task<bool> Insert(song entity)
        {
            return await Task.Run(() => {
                try
                {
                    _context.song.Add(entity);
                    return true;
                }
                catch
                {
                    return false;
                }
            });
        }

        public async Task<bool> Update(int id, song entity)
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
                    song song_ = _context.song.Find(id);
                    _context.song.Remove(song_);
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
