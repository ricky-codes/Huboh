using System;
using System.Threading.Tasks;
using Huboh.Domain.Repository;
using Huboh.EntityFramework.Models;

namespace Huboh.Domain.Services
{
    public class UnitOfWork : IDisposable
    {

        private HubohDBEntities _context = new HubohDBEntities();
        private GenericRepository<song> _songRepository;
        private GenericRepository<playlist> _playlistRepository;


        public GenericRepository<song> SongRepository
        {
            get
            {
                if(this._songRepository == null)
                {
                    this._songRepository = new GenericRepository<song>(_context);
                }
                return _songRepository;
            }
        }

        public GenericRepository<playlist> PlaylistRepository
        {
            get
            {
                if (this._playlistRepository == null)
                {
                    this._playlistRepository = new GenericRepository<playlist>(_context);
                }
                return _playlistRepository;
            }
        }

        public bool Save()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }        
        }



        #region IDisposable Support
        private bool disposed = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
