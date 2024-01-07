using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShootEmUp
{
    public sealed class CountDownManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject countdownField;

        [SerializeField]
        private float timeInterval = 3;

        private bool isTimerCounting = false;

        private void Awake()
        {
            countdownField.SetActive(false);
        }
        private void Update()
        {
            if(isTimerCounting)
            {
                if(timeInterval > 0)
                {
                    timeInterval -= Time.deltaTime;
                    DisplayTime(timeInterval);
                }
                else
                {
                    timeInterval = 0;
                    isTimerCounting = false;
                    Debug.Log("Time is up!");
                    SceneManager.LoadScene(1);
                }
            }
        }

        private void DisplayTime(float timeToDisplay)
        {
            var remainingSeconds = Mathf.FloorToInt(timeToDisplay % 60);
            if(countdownField.TryGetComponent(out TextMeshProUGUI textMesh))
            {
                var text = remainingSeconds <= 0 ? string.Empty : string.Format("{0:0}", remainingSeconds);
                textMesh.text = text;
            }
        }

        public void StartCountDown()
        {
            isTimerCounting = true;
            countdownField.SetActive(true);
        }
    }
}
