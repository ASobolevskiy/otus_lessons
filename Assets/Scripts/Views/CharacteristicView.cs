using Homework4.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Homework4.Views
{
    class CharacteristicView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text characteristicText;

        public void Init(IPresenter args)
        {
        }
    }
}
