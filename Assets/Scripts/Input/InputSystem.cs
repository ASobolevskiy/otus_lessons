using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputSystem : MonoBehaviour,
        Listeners.IGameStartListener,
        Listeners.IGamePauseListener,
        Listeners.IGameResumeListener,
        Listeners.IGameFinishListener,
        Listeners.IGameUpdateListener
    {

        public event Action OnFire;
        public event Action<Vector2> OnMove;

        private void Awake()
        {
            enabled = false;
        }

        public void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnFire?.Invoke();
            }
            OnMove?.Invoke(GetMovementDirection());
        }

        private Vector2 GetMovementDirection()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                return Vector2.left;
            return Input.GetKey(KeyCode.RightArrow) ? Vector2.right : Vector2.zero;
        }

        public void OnGameStart()
        {
            enabled = true;
        }

        public void OnGamePause()
        {
            enabled = false;
        }

        public void OnGameResume()
        {
            enabled = true;
        }

        public void OnGameFinish()
        {
            enabled = false;
        }
    }
}