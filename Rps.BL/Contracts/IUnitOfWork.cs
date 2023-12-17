using AllPhiConsultantRecruiter.DAL.Repositories.Contracts;
using Rps.Domain;

namespace Rps.BL.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Player> PlayerRepo { get; }
        IGenericRepository<RpsMatch> RpsMatchRepo { get; }
        IGenericRepository<Setting> SettingRepo { get; }
        IGenericRepository<Robot> RobotRepo { get; }
        int Save();
    }
}
