using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ArganTest.Features.DataAccess.Context;
using ArganTest.Features.DataAccess.Entities;
using Unity;

namespace ArganTest.Features.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        [Dependency]
        public ArganDbContext DbContext { get; set; }

        protected virtual DbSet<T> DbSet => DbContext.Set<T>();
        protected virtual IQueryable<T> SetWithRelatedEntitiesAsNoTracking => DbContext.Set<T>().AsNoTracking();

        public virtual T GetById(int id)
        {
            return SetWithRelatedEntitiesAsNoTracking.SingleOrDefault(c => c.Id == id);
        }

        public List<T> GetAll()
        {
            return SetWithRelatedEntitiesAsNoTracking.ToList();
        }

        public T Add(T obj)
        {
            var result = DbSet.Add(obj);
            return result;
        }

        public T Update(T obj)
        {
            DbContext.Entry(obj).State = EntityState.Modified;
            return obj;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            DbSet.Remove(entity);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Task.FromResult(SetWithRelatedEntitiesAsNoTracking.SingleOrDefault(e => e.Id == id));
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await SetWithRelatedEntitiesAsNoTracking.ToListAsync();
        }

        public async Task<T> AddAsync(T obj)
        {
            var result = DbSet.Add(obj);
            return await Task.FromResult(result);
        }

        public async Task<T> UpdateAsync(T obj)
        {
            DbContext.Entry(obj).State = EntityState.Modified;
            return await Task.FromResult(obj);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            DbSet.Remove(entity);
        }
    }
}