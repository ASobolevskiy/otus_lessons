using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class LevelBackground : MonoBehaviour
    {
        float startPositionY;

        float endPositionY;

        float movingSpeedY;

        float positionX;

        float positionZ;

        Transform myTransform;

        [SerializeField]
        Params parameters;

        void Awake()
        {
            startPositionY = parameters.startPositionY;
            endPositionY = parameters.endPositionY;
            movingSpeedY = parameters.movingSpeedY;
            myTransform = transform;
            var position = myTransform.position;
            positionX = position.x;
            positionZ = position.z;
        }

        void FixedUpdate()
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
                movingSpeedY * Time.fixedDeltaTime,
                positionZ
            );
        }

        [Serializable]
        public sealed class Params
        {
            [SerializeField]
            public float startPositionY;

            [SerializeField]
            public float endPositionY;

            [SerializeField]
            public float movingSpeedY;
        }
    }
}