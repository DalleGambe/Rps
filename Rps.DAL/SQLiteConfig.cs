using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.SQLite;
using System.Data.SQLite.EF6;

//TODO fix this later
//Source: https://youtu.be/66K5Nmmc9g8?t=565
namespace Rps.DAL
{
    public class SQLiteConfig : DbConfiguration
    {
        public SQLiteConfig() {
            SetProviderFactory("System.Data.SQLite", SQLiteFactory.Instance);
            SetProviderFactory("System.Data.SQLite.EF6", SQLiteProviderFactory.Instance);
        }
    }
}
