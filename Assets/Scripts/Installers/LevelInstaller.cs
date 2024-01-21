using ShootEmUp.DI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp.Installers
{
    class LevelInstaller : MonoBehaviour,
        Providers.IGameListenerProvider,
        Providers.IServiceProvider,
        Providers.IInjectProvider
    {
        [SerializeField]
        private LevelBackground levelBackground;

        [SerializeField]
        private LevelBackgoundParams backgroundParams;

        [Space]

        [SerializeField]
        private LevelBounds levelBounds;

        public IEnumerable<Listeners.IGameListener> ProvideListeners()
        {
            yield return levelBackground;
        }

        public IEnumerable<(Type, object)> ProvideServices()
        {
            yield return (typeof(LevelBounds), levelBounds);
        }

        public void Inject(ServiceLocator serviceLocator)
        {
            levelBackground.Construct(backgroundParams);
        }

    }
}
