using System;
using System.Threading.Tasks;
using Huboh.Domain.Repository;
using Huboh.EntityFramework.Models;

namespace Huboh.Domain.Services
{
    public class UnitOfWork : IDisposable
    {

        private HubohDB_v1Entities _context = new HubohDB_v1Entities();


        //Lyrics Repository not in use
        private GenericRepository<Songs> _songRepository;
        private GenericRepository<Artists> _artistsRepository;
        private GenericRepository<Albums> _albumsRepository;
        private GenericRepository<Genres> _genresRepository;
        private GenericRepository<Publishers> _publishersRepository;
        private GenericRepository<Composers> _composersRepository;
        private GenericRepository<FilePaths> _filepathsRepository;


        public GenericRepository<Songs> SongsRepository
        {
            get
            {
                if(this._songRepository == null)
                {
                    this._songRepository = new GenericRepository<Songs>(_context);
                }
                return _songRepository;
            }
        }

        public GenericRepository<Artists> ArtistsRepository
        {
            get
            {
                if (this._artistsRepository == null)
                {
                    this._artistsRepository = new GenericRepository<Artists>(_context);
                }
                return _artistsRepository;
            }
        }
        
        public GenericRepository<Albums> AlbumsRepository
        {
            get
            {
                if (this._albumsRepository == null)
                {
                    this._albumsRepository = new GenericRepository<Albums>(_context);
                }
                return _albumsRepository;
            }
        }
        
        public GenericRepository<Genres> GenresRepository
        {
            get
            {
                if (this._genresRepository == null)
                {
                    this._genresRepository = new GenericRepository<Genres>(_context);
                }
                return _genresRepository;
            }
        }
        
        public GenericRepository<Publishers> PublishersRepository
        {
            get
            {
                if (this._publishersRepository == null)
                {
                    this._publishersRepository = new GenericRepository<Publishers>(_context);
                }
                return _publishersRepository;
            }
        }
        
        public GenericRepository<Composers> ComposersRepository
        {
            get
            {
                if (this._composersRepository == null)
                {
                    this._composersRepository = new GenericRepository<Composers>(_context);
                }
                return _composersRepository;
            }
        }
        
        public GenericRepository<FilePaths> FilepathsRepository
        {
            get
            {
                if (this._filepathsRepository == null)
                {
                    this._filepathsRepository = new GenericRepository<FilePaths>(_context);
                }
                return _filepathsRepository;
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
