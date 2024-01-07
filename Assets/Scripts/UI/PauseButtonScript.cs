using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShootEmUp.UI
{
    public class PauseButtonScript : MonoBehaviour,
        Listeners.IGameStartListener,
        Listeners.IGamePauseListener,
        Listeners.IGameResumeListener
    {
        [SerializeField]
        private GameManager gameManager;

        private TextMeshProUGUI buttonText;

        private const string PAUSE_TEXT = "Pause";
        private const string RESUME_TEXT = "Resume";


        private void Awake()
        {
            buttonText = GetComponentInChildren<TextMeshProUGUI>();
        }
        public void OnButtonPressed()
        {
            switch(gameManager.gameState)
            {
                case GameState.Start:
                case GameState.Resume:
                    gameManager.HandlePause();
                    break;
                case GameState.Pause:
                    gameManager.HandleResume();
                    break;
                default:
                    return;
            }
        }

        public void OnGameStart()
        {
            buttonText.text = PAUSE_TEXT;
        }

        public void OnGamePause()
        {
            buttonText.text = RESUME_TEXT;
        }

        public void OnGameResume()
        {
            buttonText.text = PAUSE_TEXT;
        }
    }
}