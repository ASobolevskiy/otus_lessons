using ShootEmUp.DI;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace ShootEmUp
{
    [Serializable]
    public sealed class EnemyCooldownSpawner :
        Listeners.IGameStartListener,
        Listeners.IGamePauseListener,
        Listeners.IGameResumeListener,
        Listeners.IGameFinishListener
    {
        [SerializeField]
        private float spawnDelayInSeconds = 1f;

        private bool isGameRunning;
        private EnemySpawner enemySpawner;
        private CancellationTokenSource cts;

        [Inject]
        public void Construct(EnemySpawner enemySpawner)
        {
            Debug.Log($"{nameof(EnemyCooldownSpawner)} Construct called");
            this.enemySpawner = enemySpawner;
        }

        private async Task StartSpawningTask(CancellationToken ct)
        {
            while (isGameRunning && !ct.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromSeconds(spawnDelayInSeconds));
                enemySpawner.SpawnEnemy();
            }
        }

        public void OnGameStart()
        {
            isGameRunning = true;
            cts = new CancellationTokenSource();
            _ = StartSpawningTask(cts.Token);
        }

        public void OnGamePause()
        {
            isGameRunning = false;
            cts.Cancel();
            cts.Dispose();
        }

        public void OnGameResume()
        {
            isGameRunning = true;
            cts = new();
            _ = StartSpawningTask(cts.Token);
        }

        public void OnGameFinish()
        {
            isGameRunning = false;
            cts.Cancel();
            cts.Dispose();
        }
    }
}