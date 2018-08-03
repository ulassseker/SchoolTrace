
namespace CP.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void SaveChanges();
    }
}
