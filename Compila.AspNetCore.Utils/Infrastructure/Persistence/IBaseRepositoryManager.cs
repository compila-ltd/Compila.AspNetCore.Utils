namespace Compila.AspNetCore.Utils.Infrastructure.Persistence
{
    public interface IBaseRepositoryManager
    {
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
