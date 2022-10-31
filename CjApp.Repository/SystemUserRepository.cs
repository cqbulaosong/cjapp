using CjApp.IRepository;
using CjApp.Model;
using SqlSugar;

namespace CjApp.Repository;

public class SystemUserRepository : BaseRepository<SystemUser>, ISystemUserRepository
{
    public SystemUserRepository(ISqlSugarClient context = null) : base(context)
    {
    }
}