using ShootEmUp.DI;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterDeathObserver :
        Listeners.IGameStartListener,
        Listeners.IGameFinishListener
    {
        private GameObject character;
        private GameManager gameManager;

        [Inject]
        public void Construct(GameObject character, GameManager gameManager)
        {
            Debug.Log($"{nameof(CharacterDeathObserver)} Construct called!");
            this.character = character;
            this.gameManager = gameManager;
        }

        private void OnCharacterDeath(GameObject _) => gameManager.HandleFinish();

        public void OnGameStart()
        {
            character.GetComponent<HitPointsComponent>().OnHpEmpty += OnCharacterDeath;
        }

        public void OnGameFinish()
        {
            character.GetComponent<HitPointsComponent>().OnHpEmpty -= OnCharacterDeath;
        }
    }
}