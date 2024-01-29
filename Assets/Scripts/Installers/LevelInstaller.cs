using ShootEmUp.DI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp.Installers
{
    class LevelInstaller : BaseInstaller
    {
        [SerializeField, Listener]
        private LevelBackground levelBackground;

        [SerializeField, Service(typeof(LevelBackgoundParams))]
        private LevelBackgoundParams backgroundParams;

        [Space]

        [SerializeField, Service(typeof(LevelBounds))]
        private LevelBounds levelBounds;
    }
}
