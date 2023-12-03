using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterDeathObserver : MonoBehaviour
    {
        [SerializeField]
        GameObject character;

        [SerializeField]
        GameManager gameManager;

        private void OnEnable()
        {
            character.GetComponent<HitPointsComponent>().OnHpEmpty += OnCharacterDeath;
        }

        private void OnDisable()
        {
            character.GetComponent<HitPointsComponent>().OnHpEmpty -= OnCharacterDeath;
        }

        private void OnCharacterDeath(GameObject _) => gameManager.FinishGame();
    }
}