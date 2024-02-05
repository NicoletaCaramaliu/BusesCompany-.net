namespace Proiect_final.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> SaveAsync();
    }
}
