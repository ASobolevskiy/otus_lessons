using UnityEngine.SceneManagement;

namespace ShootEmUp.SceneLoaders
{
    class SceneLoader
    {
        public void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
