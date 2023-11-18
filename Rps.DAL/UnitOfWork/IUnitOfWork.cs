using AllPhiConsultantRecruiter.DAL.Repositories.Contracts;
using Rps.Domain;

namespace Rps.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Player> PlayerRepo { get; }
        IGenericRepository<RpsMatch> RpsMatchRepo { get; }
        IGenericRepository<Setting> SettingRepo { get; }
        int Save();
    }
}
