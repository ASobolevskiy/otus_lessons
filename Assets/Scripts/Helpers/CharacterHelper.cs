
using Lessons.Architecture.PM;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Helpers
{
    class CharacterHelper : MonoBehaviour
    {
        UserInfo userInfo;

        [Inject]
        public void Construct(UserInfo userInfo)
        {
            this.userInfo = userInfo;
        }

        [Button]
        public void ChangeName(string name)
        {
            userInfo.ChangeName(name);
        }
    }
}
