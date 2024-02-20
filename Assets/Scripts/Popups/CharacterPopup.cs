using Homework4.Data;
using Homework4.Presenters;
using Homework4.Views;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Homework4.Popups
{
    class CharacterPopup : MonoBehaviour
    {
        [SerializeField]
        TMP_Text heroNameText;

        [SerializeField]
        TMP_Text heroDescriptionText;

        [SerializeField]
        Image heroPortrait;

        [SerializeField]
        Slider progressbar;

        [SerializeField]
        TMP_Text experienceText;

        [SerializeField]
        Button hideButton;

        [SerializeField]
        GridLayoutGroup grid;

        [SerializeField]
        CharacteristicView prefab;


        public void Show(IPresenter args)
        {
        }

        private void SetupPlayerLevel()
        {
            
        }

        private void Hide()
        {
            gameObject.SetActive(false);
            hideButton.onClick.RemoveListener(Hide);
        }
    }
}
