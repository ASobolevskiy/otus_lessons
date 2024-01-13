using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp.UI
{
    class PauseResumeButtonStateController : MonoBehaviour,
        Listeners.IGameStartListener,
        Listeners.IGamePauseListener,
        Listeners.IGameResumeListener,
        Listeners.IGameFinishListener
    {
        [SerializeField]
        private Button pauseButton;

        [SerializeField]
        private Button resumeButton;

        private void Awake()
        {
            pauseButton.gameObject.SetActive(false);
            resumeButton.gameObject.SetActive(false);
        }

        public void OnGameStart()
        {
            pauseButton.gameObject.SetActive(true);
            resumeButton.gameObject.SetActive(false);
        }

        public void OnGamePause()
        {
            pauseButton.gameObject.SetActive(false);
            resumeButton.gameObject.SetActive(true);

        }

        public void OnGameResume()
        {
            pauseButton.gameObject.SetActive(true);
            resumeButton.gameObject.SetActive(false);

        }
        public void OnGameFinish()
        {
            pauseButton.gameObject.SetActive(false);
            resumeButton.gameObject.SetActive(false);
        }
    }
}
