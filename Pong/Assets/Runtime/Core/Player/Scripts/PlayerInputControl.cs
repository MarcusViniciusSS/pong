using UnityEngine;
using UnityEngine.InputSystem;

namespace Runtime.Core.Player.Scripts
{
    public class PlayerInputControl : MonoBehaviour
    {
        [SerializeField] private GameObject playerGameObject;
        [SerializeField] private float startPositionX = -7.0f;

        private PlayerInput _playerInput;
        private InputAction _touchPositionAction;
        private Camera _camera;

        private PlayerController _playerController;

        private void Awake()
        {
            _camera = Camera.main;
            _playerInput = GetComponent<PlayerInput>();
            _touchPositionAction = _playerInput.actions["MovementTouchPosition"];

            _playerController = new PlayerController(playerGameObject, _camera);
        }

        private void OnEnable() => _touchPositionAction.performed += TouchPosition;

        private void OnDisable() => _touchPositionAction.performed -= TouchPosition;

        private void TouchPosition(InputAction.CallbackContext context)
        { 
            var valueTouchPosition = _touchPositionAction.ReadValue<Vector2>();
            _playerController.MovementTouch(valueTouchPosition, startPositionX);
        }
    }
}