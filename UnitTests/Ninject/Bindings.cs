using Ninject.Modules;
using OnionArchitecture.Core.Interfaces.Repositories;
using OnionArchitecture.Core.Interfaces.Services;
using OnionArchitecture.Infra.Context;
using OnionArchitecture.Infra.Repositories;
using OnionArchitecture.Infra.Services;

namespace UnitTests.Ninject
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IOnionArchitectureContext)).To(typeof(OnionArchitectureContext)).InSingletonScope();
            Bind(typeof(IUserRepository)).To(typeof(UserRepositoy)).InSingletonScope();
            Bind(typeof(IUserService)).To(typeof(UserService)).InSingletonScope();
        }
    }
}