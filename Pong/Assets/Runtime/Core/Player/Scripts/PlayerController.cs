using UnityEngine;

namespace Runtime.Core.Player.Scripts
{
    public class PlayerController
    {
        private readonly GameObject _playerGameObject;
        private readonly Camera _camera;

        public PlayerController(GameObject playerGameObject, Camera camera)
        {
            _playerGameObject = playerGameObject;
            _camera = camera;
        }
        
        public void MovementTouch(Vector2 touchValue, float startPositionX)
        {
            var position = _camera!.ScreenToWorldPoint(touchValue);
            position.x = startPositionX;
            position.z = _playerGameObject.transform.position.z;
            _playerGameObject.transform.position = position;
        }
    }
}
