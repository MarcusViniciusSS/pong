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

        private void Awake()
        {
            _camera = Camera.main;
            _playerInput = GetComponent<PlayerInput>();
            _touchPositionAction = _playerInput.actions["MovementTouchPosition"];
        }

        private void OnEnable() => _touchPositionAction.performed += TouchPosition;

        private void OnDisable() => _touchPositionAction.performed -= TouchPosition;

        private void TouchPosition(InputAction.CallbackContext context)
        {
            var position = _camera!.ScreenToWorldPoint(_touchPositionAction.ReadValue<Vector2>());
            position.x = startPositionX;
            position.z = playerGameObject.transform.position.z;
            playerGameObject.transform.position = position;
            
            Debug.Log(position);
        }
    }
}