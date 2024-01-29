using ShootEmUp.DI;

namespace ShootEmUp
{
    public sealed class Listeners
    {
        public interface IGameListener { }
        public interface IGameStartListener : IGameListener
        {
            void OnGameStart();
        }

        public interface IGameFinishListener : IGameListener
        {
            void OnGameFinish();
        }

        public interface IGamePauseListener : IGameListener
        {
            void OnGamePause();
        }

        public interface IGameResumeListener : IGameListener
        {
            void OnGameResume();
        }

        public interface IGameUpdateListener : IGameListener
        {
            void OnUpdate(float deltaTime);
        }

        public interface IGameFixedUpdateListener : IGameListener
        {
            void OnFixedUpdate(float fixedDeltaTime);
        }
    }
}