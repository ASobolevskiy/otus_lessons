using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterMoveController : MonoBehaviour,
        Listeners.IGameStartListener,
        Listeners.IGameFinishListener
    {
        [SerializeField]
        private InputSystem input;

        [SerializeField]
        private GameObject character;

        private void SetDirection(Vector2 direction)
        {
            if (character.TryGetComponent(out MoveComponentBase moveComponent))
            {
                moveComponent.SetDirection(direction);
            }
        }

        public void OnGameStart()
        {
            input.OnMove += SetDirection;
        }

        public void OnGameFinish()
        {
            input.OnMove -= SetDirection;
        }
    }
}

