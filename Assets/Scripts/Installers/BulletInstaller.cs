using ShootEmUp.DI;
using ShootEmUp.Factories;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp.Installers
{
    class BulletInstaller : BaseInstaller
    {
        [SerializeField, Service(typeof(BulletConfig))]
        private BulletConfig bulletConfig;

        [SerializeField, Listener, Service(typeof(BulletPool))]
        private BulletPool bulletPool;

        [SerializeField, Service(typeof(BulletFactory))]
        private BulletFactory bulletFactory;

        [Service(typeof(BulletSystem))]
        private readonly BulletSystem bulletSystem = new();
    }
}
