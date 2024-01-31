using Assets.Scripts.Logs;
using Zenject;

namespace Assets.Scripts.Installers
{
    class SceneContextInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<LogController>().AsSingle().NonLazy();
        }
    }
}
