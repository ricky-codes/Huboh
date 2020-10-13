using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huboh.Domain.Services
{
    public interface IDataRepository<T> where T : class
    {
        //Returns all rows from the given entity
        IEnumerable<T> GetAll();

        //Returns an element selected by id
        T GetByID(int id);

        //Inserts an element onto an entity
        bool Insert(T entity);

        //Updates a value of an element given its ID and the value
        bool Update(int id, T entity);

        //Delete an element
        bool Delete(int id);
    }
}
