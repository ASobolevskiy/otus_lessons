using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyCooldownSpawner : MonoBehaviour,
        Listeners.IGameStartListener,
        Listeners.IGamePauseListener,
        Listeners.IGameResumeListener,
        Listeners.IGameFinishListener
    {
        [SerializeField]
        private EnemySpawner enemySpawner;

        [SerializeField]
        private float spawnDelayInSeconds = 1f;

        private bool isGameRunning;

        private IEnumerator StartSpawning()
        {
            while (isGameRunning)
            {
                yield return new WaitForSeconds(spawnDelayInSeconds);
                enemySpawner.SpawnEnemy();
            }
        }

        public void OnGameStart()
        {
            isGameRunning = true;
            StartCoroutine(StartSpawning());
        }

        public void OnGamePause()
        {
            isGameRunning = false;
            StopCoroutine(StartSpawning());
        }

        public void OnGameResume()
        {
            isGameRunning = true;
            StartCoroutine(StartSpawning());
        }

        public void OnGameFinish()
        {
            isGameRunning = false;
            StopCoroutine(StartSpawning());
        }
    }
}

