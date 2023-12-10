using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterDeathObserver : MonoBehaviour,
        Listeners.IGameStartListener,
        Listeners.IGameFinishListener
    {
        [SerializeField]
        private GameObject character;

        [SerializeField]
        private GameManager gameManager;

        private void OnCharacterDeath(GameObject _) => gameManager.FinishGame();

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