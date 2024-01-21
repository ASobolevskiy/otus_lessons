using UnityEngine;

namespace ShootEmUp
{
    public sealed class CharacterMoveController :
        Listeners.IGameStartListener,
        Listeners.IGameFinishListener
    {
        private InputSystem input;
        private GameObject character;

        public void Construct(InputSystem inputSystem, GameObject character)
        {
            Debug.Log($"{nameof(CharacterMoveController)} Construct called!");
            input = inputSystem;
            this.character = character;
        }

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

