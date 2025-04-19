using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INT.Domain.Domain.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void UpdateAndSave(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
        bool IsExist(object id);
        Task<bool> IsExistAsync(object id);
        Task<T> GetByIdAsync(object id);
        Task SaveAsync();
        Task InsertAsync(T obj);
        Task InsertAllAsync(IEnumerable<T> list);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
