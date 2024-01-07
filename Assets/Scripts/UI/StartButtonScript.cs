using ShootEmUp;
using UnityEngine;

namespace ShootEmUp.UI
{
    public sealed class StartButtonScript : MonoBehaviour
    {
        [SerializeField]
        private CountDownManager countDownMngr;

        public void OnStartButtonClicked()
        {
            this.gameObject.SetActive(false);
            countDownMngr.StartCountDown();
        }
    }
}

