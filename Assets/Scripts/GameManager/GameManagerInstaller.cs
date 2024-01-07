using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    [RequireComponent(typeof(GameManager))]
    public sealed class GameManagerInstaller : MonoBehaviour
    {
        private GameManager gameManager;
        private void Awake()
        {
            gameManager = GetComponent<GameManager>();

            Listeners.IGameStartListener[] startGameListeners = GetComponentsInChildren<Listeners.IGameStartListener>();
            Listeners.IGamePauseListener[] pauseGameListeners = GetComponentsInChildren<Listeners.IGamePauseListener>();
            Listeners.IGameResumeListener[] resumeGameListeners = GetComponentsInChildren<Listeners.IGameResumeListener>();
            Listeners.IGameFinishListener[] finishGameListeners = GetComponentsInChildren<Listeners.IGameFinishListener>();
            Listeners.IGameUpdateListener[] updateListeners = GetComponentsInChildren<Listeners.IGameUpdateListener>();
            Listeners.IGameFixedUpdateListener[] fixedUpdateListeners = GetComponentsInChildren<Listeners.IGameFixedUpdateListener>();

            gameManager.AddGameStartListeners(startGameListeners);
            gameManager.AddGamePauseListeners(pauseGameListeners);
            gameManager.AddGameResumeListeners(resumeGameListeners);
            gameManager.AddGameFinishListeners(finishGameListeners);
            gameManager.AddGameUpdateListeners(updateListeners);
            gameManager.AddGameFixedUpdateListeners(fixedUpdateListeners);
            gameManager.HandleStart();
        }
    }
}
