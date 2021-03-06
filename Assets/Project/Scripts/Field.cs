using UnityEngine;

namespace Project.Scripts {
    public class Field : MonoBehaviour {
        [SerializeField] private Transform topLeftPoint;
        [SerializeField] private Transform bottomRightPoint;

        public Vector2 GetPositionInRelativeFormat(Vector2 position) {
            var topLeftPos = topLeftPoint.position;
            var bottomRightPos = bottomRightPoint.position;
            var relativeX = (position.x - topLeftPos.x) / (bottomRightPos.x - topLeftPos.x);
            var relativeY= (position.y - bottomRightPos.y) / (topLeftPos.y - bottomRightPos.y);
            return new Vector2(relativeX, relativeY);
        }
    }
}