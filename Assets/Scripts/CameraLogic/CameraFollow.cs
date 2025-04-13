using UnityEngine;

namespace Assets.Scripts.CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        [Header("Настройки положения камеры")]
        [SerializeField] private Transform _following;
        [SerializeField] private float _rotationX;
        [SerializeField] private int _distance;
        [SerializeField] private float _offset;

        [Header ("Настройки зума камеры")]
        [SerializeField] private float zoomSpeed = 5f;
        [SerializeField] private float minZoom = 10f;
        [SerializeField] private float maxZoom = 50f;

        private void LateUpdate()
        {
            if (_following == null)
                return;

            Quaternion rotation = Quaternion.Euler(_rotationX, 0, 0);
            Vector3 position = rotation * new Vector3(0, 0, -_distance) + FollowingPointPosition();

            transform.rotation = rotation;
            transform.position = position;

            Zoom();
        }

        public void Follow(GameObject following) =>
            _following = following.transform;

        private void Zoom()
        {
            float scroll = Input.mouseScrollDelta.y;

            if (scroll != 0)
            {
                float zoomAmount = scroll * zoomSpeed * Time.deltaTime;
                Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - zoomAmount, minZoom, maxZoom);
            }
        }

        private Vector3 FollowingPointPosition()
        {
            Vector3 followingPosition = _following.position;
            followingPosition.y += _offset;

            return followingPosition;
        }
    }
}