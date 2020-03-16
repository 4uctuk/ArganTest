using System.Collections.Generic;
using System.Threading.Tasks;
using ArganTest.Features.DataAccess.Entities;

namespace ArganTest.Features.DataAccess.Repositories
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        T GetById(int id);
        List<T> GetAll();
        T Add(T obj);
        T Update(T obj);
        void Delete(int id);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task DeleteAsync(int id);
    }
}
