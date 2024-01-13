using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp.UI
{
    class PauseResumeButtonHandler : MonoBehaviour,
        Listeners.IGameStartListener,
        Listeners.IGameFinishListener

    {
        [Header("References")]
        [SerializeField]
        private GameManager gameManager;
        [Space]
        [SerializeField]
        private Button pauseButton;

        [SerializeField]
        private Button resumeButton;

        public void OnGameStart()
        {
            pauseButton.onClick.AddListener(PauseGame);
            resumeButton.onClick.AddListener(ResumeGame);
        }

        public void OnGameFinish()
        {
            pauseButton.onClick.RemoveListener(PauseGame);
            resumeButton.onClick.RemoveListener(ResumeGame);
        }

        private void PauseGame()
        {
            gameManager.HandlePause();
        }
        private void ResumeGame()
        {
            gameManager.HandleResume();
        }
    }
}

