using UnityEngine;

namespace ShootEmUp
{
    public sealed class LevelBounds : MonoBehaviour
    {
        [SerializeField]
        Transform leftBorder;

        [SerializeField]
        Transform rightBorder;

        [SerializeField]
        Transform downBorder;

        [SerializeField]
        Transform topBorder;

        public bool InBounds(Vector3 position)
        {
            var positionX = position.x;
            var positionY = position.y;
            return positionX > leftBorder.position.x
                   && positionX < rightBorder.position.x
                   && positionY > downBorder.position.y
                   && positionY < topBorder.position.y;
        }
    }
}