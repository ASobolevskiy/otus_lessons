using ShootEmUp.DI;
using ShootEmUp.SceneLoaders;
using System;
using UnityEngine;

namespace ShootEmUp
{
    class GameFinishObserver : MonoBehaviour
    {
        private GameManager gameManager;
        private SceneLoader sceneLoader;

        private const int LOADING_SCENE_INDEX = 0;

        [Inject]
        public void Construct(GameManager gameManager, SceneLoader sceneLoader)
        {
            Debug.Log($"{nameof(GameFinishObserver)} Construct called!");
            this.gameManager = gameManager;
            this.sceneLoader = sceneLoader;
            this.gameManager.GameFinished += HandleFinishedGame;
        }
        private void OnDestroy()
        {
            gameManager.GameFinished -= HandleFinishedGame;
        }

        private void HandleFinishedGame()
        {
            sceneLoader.LoadScene(LOADING_SCENE_INDEX);
        }
    }
}