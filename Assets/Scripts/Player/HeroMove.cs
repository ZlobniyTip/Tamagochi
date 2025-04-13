using Assets.Scripts.Services.Input;
using Assets.Scripts.Infrastructure;
using UnityEngine;
using Assets.Scripts;
using Cysharp.Threading.Tasks;

namespace Scripts.Player
{
    public class HeroMove : MonoBehaviour
    {
        [SerializeField] private CharacterController _controller;
        [SerializeField] private float _movementSpeed;

        private Camera _camera;
        private IInputService _input;
        private Vector3 _movementVector;

        private void Awake()
        {
            _input = Game.InputService;
        }

        private void Start()
        {
            _camera = Camera.main;

            Move().Forget();
        }

        private async UniTaskVoid Move()
        {
            while (true)
            {
                _movementVector = Vector3.zero;

                if (_input.Axis.sqrMagnitude > Constants.Epsilon)
                {
                    _movementVector = _camera.transform.TransformDirection(_input.Axis);
                    _movementVector.y = 0;
                    _movementVector.Normalize();

                    transform.forward = _movementVector;
                    _movementVector += Physics.gravity;
                }

                _controller.Move(_movementVector * _movementSpeed * Time.deltaTime);

                await UniTask.NextFrame();
            }
        }
    }
}