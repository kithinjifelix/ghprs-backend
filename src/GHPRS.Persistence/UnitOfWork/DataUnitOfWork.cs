using GHPRS.Core.UnitOfWork;

namespace GHPRS.Persistence.UnitOfWork
{
    public class DataUnitOfWork : BaseUnitOfWork, IDataUnitOfWork
    {
        public DataUnitOfWork(DataContext context) : base(context)
        {
        }
    }
}