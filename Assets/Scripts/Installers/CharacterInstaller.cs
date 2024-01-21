using ShootEmUp.DI;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp.Installers
{
    class CharacterInstaller : MonoBehaviour,
        Providers.IGameListenerProvider,
        Providers.IServiceProvider,
        Providers.IInjectProvider
    {
        [SerializeField]
        private GameObject character;

        private CharacterDeathObserver characterDeathObserver = new();
        private CharacterFireController characterFireController = new();
        private CharacterMoveController characterMoveController = new();

        public IEnumerable<Listeners.IGameListener> ProvideListeners()
        {
            yield return characterFireController;
            yield return characterMoveController;
            yield return characterDeathObserver;
        }

        public IEnumerable<(Type, object)> ProvideServices()
        {
            yield return (typeof(GameObject), character);
        }

        public void Inject(ServiceLocator serviceLocator)
        {
            characterFireController.Construct(character,
                                              serviceLocator.GetService<BulletSystem>(),
                                              serviceLocator.GetService<BulletConfig>(),
                                              serviceLocator.GetService<InputSystem>());

            characterMoveController.Construct(serviceLocator.GetService<InputSystem>(), character);

            characterDeathObserver.Construct(character, serviceLocator.GetService<GameManager>());
        }
    }
}
