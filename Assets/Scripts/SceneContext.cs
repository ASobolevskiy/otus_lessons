using ShootEmUp;
using ShootEmUp.DI;
using ShootEmUp.SceneLoaders;
using UnityEngine;

namespace ShootEmUp
{
    class SceneContext : MonoBehaviour
    {
        [SerializeField]
        private GameManager gameManager;

        [SerializeField]
        private ServiceLocator serviceLocator;

        [SerializeField]
        private MonoBehaviour[] modules;

        private SceneLoader sceneLoader = new();

        private void Awake()
        {
            for (int i = 0; i < modules.Length; i++)
            {
                if (modules[i] is Providers.IGameListenerProvider listenersProvider)
                {
                    gameManager.AddGameListeners(listenersProvider.ProvideListeners());
                }
                if (modules[i] is Providers.IServiceProvider tProvider)
                {
                    serviceLocator.BindServices(tProvider.ProvideServices());
                }
            }
            var listeners = GetComponentsInChildren<Listeners.IGameListener>();
            gameManager.AddGameListeners(listeners);

            serviceLocator.BindService(typeof(GameManager), gameManager);
            serviceLocator.BindService(typeof(SceneLoader), sceneLoader);
        }

        private void Start()
        {
            for (int i = 0; i < modules.Length; i++)
            {
                if (modules[i] is Providers.IInjectProvider tProvider)
                {
                    tProvider.Inject(serviceLocator);
                }
            }

            GameObject[] rootGameObjects = gameObject.scene.GetRootGameObjects();
            for (int i = 0; i < rootGameObjects.Length; i++)
            {
                GameObject target = rootGameObjects[i];
                StartInjection(target.transform);
            }

            gameManager.HandleStart();
        }

        private void StartInjection(Transform targetTransform)
        {
            MonoBehaviour[] targets = targetTransform.GetComponents<MonoBehaviour>();
            for (int i = 0; i < targets.Length; i++)
            {
                DependencyInjector.Inject(targets[i], serviceLocator);
            }

            foreach (Transform child in targetTransform)
            {
                StartInjection(child);
            }
        }
    }
}
