﻿using Homework4.Data;
using Zenject;

namespace Assets.Scripts.Installers
{
    class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<UserInfo>().AsSingle().NonLazy();
            Container.Bind<PlayerLevel>().AsSingle().NonLazy();
        }
    }
}
