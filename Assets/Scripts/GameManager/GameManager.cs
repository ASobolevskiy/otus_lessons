using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour
    {
        [NonSerialized]
        public GameState gameState = GameState.None;

        private List<Listeners.IGameStartListener> gameStartListeners = new();
        private List<Listeners.IGamePauseListener> gamePauseListeners = new();
        private List<Listeners.IGameResumeListener> gameResumeListeners = new();
        private List<Listeners.IGameFinishListener> gameFinishListeners = new();
        private List<Listeners.IGameUpdateListener> gameUpdateListeners = new();
        private List<Listeners.IGameFixedUpdateListener> gameFixedUpdateListeners = new();

        public void AddGameStartListeners(Listeners.IGameStartListener[] listeners) => gameStartListeners.AddRange(listeners);

        public void AddGamePauseListeners(Listeners.IGamePauseListener[] listeners) => gamePauseListeners.AddRange(listeners);

        public void AddGameResumeListeners(Listeners.IGameResumeListener[] listeners) => gameResumeListeners.AddRange(listeners);

        public void AddGameFinishListeners(Listeners.IGameFinishListener[] listeners) => gameFinishListeners.AddRange(listeners);

        public void AddGameUpdateListeners(Listeners.IGameUpdateListener[] listeners) => gameUpdateListeners.AddRange(listeners);

        public void AddGameFixedUpdateListener(Listeners.IGameFixedUpdateListener listener) => gameFixedUpdateListeners.Add(listener);

        public void AddGameFixedUpdateListeners(Listeners.IGameFixedUpdateListener[] listeners) => gameFixedUpdateListeners.AddRange(listeners);

        public void RemoveGameFixedUpdateListener(Listeners.IGameFixedUpdateListener listener) => gameFixedUpdateListeners.Remove(listener);

        public void HandleStart()
        {
            if(gameState == GameState.None)
            {
                Debug.Log("Game started!");
                gameState = GameState.Start;
                var scale = Time.timeScale;
                gameStartListeners.ForEach(l => l.OnGameStart());
            }
            else
            {
                Debug.Log("Game is already running!");
            }
        }

        public void HandlePause()
        {
            if(gameState == GameState.Start || gameState == GameState.Resume)
            {
                Debug.Log("Game paused!");
                gameState = GameState.Pause;
                Time.timeScale = 0;
                gamePauseListeners.ForEach(l => l.OnGamePause());
            }
            else
            {
                Debug.Log("Cannot pause not running game!");
            }
            
        }

        public void HandleResume()
        {
            if(gameState == GameState.Pause)
            {
                Debug.Log("Game resumed!");
                gameState = GameState.Resume;
                Time.timeScale = 1;
                gameResumeListeners.ForEach(l => l.OnGameResume());
            }
            else
            {
                Debug.Log("Cannot resume: game is not paused!");
            }
        }

        public void HandleFinish()
        {
            if(gameState != GameState.None)
            {
                Debug.Log("Game finished!");
                gameState = GameState.Finish;
                gameFinishListeners.ForEach(l => l.OnGameFinish());
                SceneManager.LoadScene(0);
            }
            else
            {
                Debug.Log("Game is not started yet!");
            }
        }

        public void FinishGame()
        {
            Time.timeScale = 0;
            HandleFinish();
        }

        private void Update()
        {
            if(gameState == GameState.Start || gameState == GameState.Resume)
            {
                for (int i = 0; i < gameUpdateListeners.Count; i++)
                {
                    gameUpdateListeners[i].OnUpdate();
                }
            }
        }

        private void FixedUpdate()
        {
            if(gameState == GameState.Start || gameState == GameState.Resume)
            {
                for (int i = 0; i < gameFixedUpdateListeners.Count; i++)
                {
                    gameFixedUpdateListeners[i].OnFixedUpdate(Time.fixedDeltaTime);
                }
            }
        }
    }
}