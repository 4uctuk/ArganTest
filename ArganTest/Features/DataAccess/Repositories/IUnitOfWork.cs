using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArganTest.Features.DataAccess.Repositories
{
    public interface IUnitOfWork
    {
        ITestCategoryRepository TestCategoryRepository { get; }

        ITestOrderProductRepository TestOrderProductRepository { get; }

        ITestOrderRepository TestOrderRepository { get; }

        ITestProductRepository TestProductRepository { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
