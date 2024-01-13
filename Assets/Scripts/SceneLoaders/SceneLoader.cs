using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShootEmUp.SceneLoaders
{
    class SceneLoader : MonoBehaviour
    {
        public void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
