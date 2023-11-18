using System;
using UnityEngine;

namespace ShootEmUp
{
    class FireController : MonoBehaviour
    {
        [SerializeField] CharacterController characterController;
        [SerializeField] InputManager input;

        private void OnEnable()
        {
            input.OnFire += Fire;
        }

        private void OnDisable()
        {
            input.OnFire -= Fire;
        }

        private void Fire()
        {
            characterController._fireRequired = true;
        }
    }
}
