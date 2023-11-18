using UnityEngine;

namespace ShootEmUp
{
    class MoveController : MonoBehaviour
    {
        Vector2 directionValue;

        [SerializeField] InputManager input;
        [SerializeField] GameObject character;

        private void OnEnable()
        {
            input.OnMove += SetDirection;
        }

        private void OnDisable()
        {
            input.OnMove -= SetDirection;
        }

        private void FixedUpdate()
        {
            var moveComponent = character.GetComponent<MoveComponent>();
            if(moveComponent != null)
                moveComponent.MoveByRigidbodyVelocity(directionValue * Time.fixedDeltaTime);
        }

        private void SetDirection(Vector2 direction) => directionValue = direction;
    }
}

