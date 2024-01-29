using ShootEmUp.DI;
using UnityEngine;

namespace ShootEmUp.Installers
{
    class CharacterInstaller : BaseInstaller
    {
        [SerializeField, Service(typeof(GameObject))]
        private GameObject character;

        [Listener]
        private readonly CharacterDeathObserver characterDeathObserver = new();

        [Listener]
        private CharacterFireController characterFireController = new();

        [Listener]
        private CharacterMoveController characterMoveController = new();
    }
}
