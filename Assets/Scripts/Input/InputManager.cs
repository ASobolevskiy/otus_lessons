using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputManager : MonoBehaviour
    {

        public Action OnFire;
        public Action<Vector2> OnMove;

        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RequestFire();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                RequestMovement(Vector2.left);

            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                RequestMovement(Vector2.right);
            }
            else
            {
                RequestMovement(Vector2.zero);
            }
        }

        void RequestFire() => OnFire?.Invoke();

        void RequestMovement(Vector2 direction) => OnMove?.Invoke(direction);
    }
}