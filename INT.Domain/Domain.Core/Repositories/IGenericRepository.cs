using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INT.Domain.Domain.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public T GetById(object id);
        public void Insert(T obj);
        public void UpdateAndSave(T obj);
        public void Update(T obj);
        public void Delete(object id);
        public void Save();
        public bool IsExist(object id);
        public Task<bool> IsExistAsync(object id);
        public Task<T> GetByIdAsync(object id);
        public Task <int> SaveAsync();
        public Task InsertAsync(T obj);
        public Task InsertAllAsync(IEnumerable<T> list);
        public Task<IEnumerable<T>> GetAllAsync();
    }
}
