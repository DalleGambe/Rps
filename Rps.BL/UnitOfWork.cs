using AllPhiConsultantRecruiter.DAL.Repositories.Contracts;
using Rps.BL.Contracts;
using Rps.DAL;
using Rps.DAL.Repositories;
using Rps.Domain;

namespace Rps.BL
{
    public class UnitOfWork : IUnitOfWork
    {
        private RpsDataContext Context { get; }

        #region Repositories
        public IGenericRepository<Player>? _playerRepo;

        public IGenericRepository<RpsMatch>? _rpsMatchRepo;

        public IGenericRepository<Setting>? _settingRepo;
        public IGenericRepository<Robot>? _robotRepo;
        #endregion

        public UnitOfWork(RpsDataContext ctx)
        {
            Context = ctx;
        }

        public IGenericRepository<Player> PlayerRepo
        {
            get
            {
                if (_playerRepo == null)
                {
                    _playerRepo = new GenericRepository<Player>(Context);
                }
                return _playerRepo;
            }
        }

        public IGenericRepository<RpsMatch> RpsMatchRepo
        {
            get
            {
                if (_rpsMatchRepo == null)
                {
                    _rpsMatchRepo = new GenericRepository<RpsMatch>(Context);
                }
                return _rpsMatchRepo;
            }
        }

        public IGenericRepository<Setting> SettingRepo
        {
            get
            {
                if (_settingRepo == null)
                {
                    _settingRepo = new GenericRepository<Setting>(Context);
                }
                return _settingRepo;
            }
        }

        public IGenericRepository<Robot> RobotRepo
        {
            get
            {
                if (_robotRepo == null)
                {
                    _robotRepo = new GenericRepository<Robot>(Context);
                }
                return _robotRepo;
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public int Save()
        {
            return Context.SaveChanges();
        }
    }
}
