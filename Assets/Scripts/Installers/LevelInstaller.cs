using Lessons.Architecture.PM;
using Zenject;

namespace Assets.Scripts.Installers
{
    class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<UserInfo>().AsSingle().NonLazy();
        }
    }
}
