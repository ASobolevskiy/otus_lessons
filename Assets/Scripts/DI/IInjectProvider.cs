using ShootEmUp.DI;

namespace ShootEmUp.Providers
{
    interface IInjectProvider
    {
        void Inject(ServiceLocator serviceLocator);
    }
}
