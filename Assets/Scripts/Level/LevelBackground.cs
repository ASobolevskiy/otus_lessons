using UnityEngine;

namespace ShootEmUp
{
    public sealed class LevelBackground : MonoBehaviour,
        Listeners.IGameFixedUpdateListener
    {
        private float startPositionY;
        private float endPositionY;
        private float movingSpeedY;
        private float positionX;
        private float positionZ;
        private Transform myTransform;
        private LevelBackgoundParams parameters;

        public void Construct(LevelBackgoundParams parameters)
        {
            Debug.Log($"{nameof(LevelBackground)} Construct called");
            this.parameters = parameters;
            startPositionY = parameters.startPositionY;
            endPositionY = parameters.endPositionY;
            movingSpeedY = parameters.movingSpeedY;
            myTransform = transform;
            var position = myTransform.position;
            positionX = position.x;
            positionZ = position.z;
        }

        public void OnFixedUpdate(float fixedDeltaTime)
        {
            if (myTransform.position.y <= endPositionY)
            {
                myTransform.position = new Vector3(
                    positionX,
                    startPositionY,
                    positionZ
                );
            }

            myTransform.position -= new Vector3(
                positionX,
                movingSpeedY * fixedDeltaTime,
                positionZ
            );
        }
    }
}