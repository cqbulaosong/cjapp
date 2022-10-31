using CjApp.IRepository;
using CjApp.IService;
using CjApp.Model;

namespace CjApp.Service;

public class SystemUserService : BaseService<SystemUser>, ISystemUserService
{
    private readonly ISystemUserRepository _iSystemUserRepository;
    public SystemUserService(ISystemUserRepository iSystemUserRepository)
    {
        _iBaseRepository = iSystemUserRepository;
        _iSystemUserRepository = iSystemUserRepository;
    }
}