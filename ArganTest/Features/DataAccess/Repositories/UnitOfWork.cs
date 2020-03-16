using System.Threading.Tasks;
using ArganTest.Features.DataAccess.Context;
using Unity;

namespace ArganTest.Features.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        [Dependency]
        public ArganDbContext DbContext { get; set; }

        public UnitOfWork(
            ITestCategoryRepository categoryRepository, 
            ITestOrderProductRepository orderProductRepository,
            ITestProductRepository productRepository,
            ITestOrderRepository orderRepository)
        {
            TestCategoryRepository = categoryRepository;
            TestOrderProductRepository = orderProductRepository;
            TestProductRepository = productRepository;
            TestOrderRepository = orderRepository;
        }

        public ITestCategoryRepository TestCategoryRepository { get; }
        public ITestOrderProductRepository TestOrderProductRepository { get; }
        public ITestOrderRepository TestOrderRepository { get; }
        public ITestProductRepository TestProductRepository { get; }

        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await DbContext.SaveChangesAsync();
        }
    }
}