
namespace Domain.Abstractions
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
