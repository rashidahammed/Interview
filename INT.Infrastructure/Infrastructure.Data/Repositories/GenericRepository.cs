using INT.Domain.Domain.Core.Repositories;
using INT.Infrastructure.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace INT.Infrastructure.Infrastructure.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public ApplicationDbContext _context;
        private Microsoft.EntityFrameworkCore.DbSet<T> _dbset = null;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {

            return _dbset.AsEnumerable<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync<T>();
        }

        public T GetById(object id)
        {
            return _dbset.Find(id);

        }
        public async Task<T> GetByIdAsync(object id)
        {
            return await _dbset.FindAsync(id);

        }

        public void Insert(T obj)
        {
            _dbset.Add(obj);
        }
        public async Task InsertAsync(T obj)
        {
            await _dbset.AddAsync(obj);
        }
        public async Task InsertAllAsync(IEnumerable<T> list)
        {
            await _dbset.AddRangeAsync(list);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
           var _result= await _context.SaveChangesAsync();
           return _result;
        }
        public void Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = _dbset.Find(id);
            _dbset.Remove(existing);
        }

        public bool IsExist(object id)
        {
            T existing = _dbset.Find(id);
            return existing != null;
        }

        public async Task<bool> IsExistAsync(object id)
        {
            T existing = await _dbset.FindAsync(id);
            return existing != null;
        }

        public void UpdateAndSave(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
