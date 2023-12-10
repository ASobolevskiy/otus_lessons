namespace ShootEmUp
{
    public sealed class Listeners
    {
        public interface IGameStartListener
        {
            void OnGameStart();
        }

        public interface IGameFinishListener
        {
            void OnGameFinish();
        }

        public interface IGamePauseListener
        {
            void OnGamePause();
        }

        public interface IGameResumeListener
        {
            void OnGameResume();
        }

        public interface IGameUpdateListener
        {
            void OnUpdate();
        }

        public interface IGameFixedUpdateListener
        {
            void OnFixedUpdate(float fixedDeltaTime);
        }

        public interface IGameLateUpdateListener
        {
            void OnLateUpdate();
        }
    }
}