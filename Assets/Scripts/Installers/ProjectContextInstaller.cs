using Assets.Scripts.Logs;
using Zenject;

namespace Assets.Scripts.Installers
{
    class ProjectContextInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ILogger>().To<Logger>().AsSingle().NonLazy();
        }
    }
}
