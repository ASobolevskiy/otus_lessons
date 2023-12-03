using UnityEngine;

namespace ShootEmUp
{
    class MoveController : MonoBehaviour
    {
        [SerializeField]
        InputSystem input;

        [SerializeField]
        GameObject character;

        private void OnEnable()
        {
            input.OnMove += SetDirection;
        }

        private void OnDisable()
        {
            input.OnMove -= SetDirection;
        }

        private void SetDirection(Vector2 direction)
        {
            if (character.TryGetComponent(out MoveComponentBase moveComponent))
            {
                moveComponent.SetDirection(direction);
            }
        }
    }
}

