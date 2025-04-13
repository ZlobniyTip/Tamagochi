using Cysharp.Threading.Tasks;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] private float _sensitivity = 10f;
    [SerializeField] private Transform _cameraTransform;

    private Vector3 _rotation;

    private void Start()
    {
        CameraRotate().Forget();
    }

    private async UniTaskVoid CameraRotate()
    {
        while (true)
        {
            if (Input.GetMouseButton(1))
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

                float mouseX = Input.GetAxis("Mouse X") * _sensitivity * Time.deltaTime;
                float mouseY = Input.GetAxis("Mouse Y") * _sensitivity * Time.deltaTime;

                _rotation.x -= mouseY;
                _rotation.y += mouseX;

                _rotation.x = Mathf.Clamp(_rotation.x, -90f, 90f);

                _cameraTransform.localEulerAngles = _rotation;
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }

            await UniTask.NextFrame();
        }
    }
}
