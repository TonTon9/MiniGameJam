using UnityEngine;

public class PlayerMovement : IMove {
    private CharacterController _charController;
    private float _speed;
    private Vector3 _totalDirection;
    private float _directionX;
    private float _directionZ;
    private float _rotationSpeed;
    
    private float _horizontalInput;
    private float _verticalInput;

    public PlayerMovement(CharacterController characterController, float speed) {
        _charController = characterController;
        _speed = speed;
    }
    
    public void Move() {
        MoveCharacter();
    }

    private void MoveCharacter() {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _directionX = _horizontalInput * _speed * Time.deltaTime;
        _directionZ = _verticalInput * _speed * Time.deltaTime;
        _totalDirection = new Vector3(_directionX, 0, _directionZ);
        _totalDirection = _charController.transform.TransformDirection(_totalDirection);
        _charController.Move(_totalDirection);
    }

    public float GetVerticalSpeed() {
        return _verticalInput;
    }

    public float GetHorizontalSpeed() {
        return _horizontalInput;
    }
}