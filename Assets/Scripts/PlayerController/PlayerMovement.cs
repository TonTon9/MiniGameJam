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
    
    private float _gravityForce;

    public PlayerMovement(CharacterController characterController, Stat speedStat) {
        _charController = characterController;
        _speed = speedStat.currentValue;
        speedStat.OnChangeValue += ChangeSpeed;
    }
    
    public void Move() {
        UseGravity();
        MoveCharacter();
    }

    private void MoveCharacter() {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _directionX = _horizontalInput * _speed * Time.deltaTime;
        _directionZ = _verticalInput * _speed * Time.deltaTime;
        _totalDirection = new Vector3(_directionX, 0, _directionZ);
        _totalDirection = _charController.transform.TransformDirection(_totalDirection);
        _totalDirection.y = _gravityForce;
        _charController.Move(_totalDirection * Time.deltaTime);
    }

    private void ChangeSpeed(float speed) {
        _speed = speed;
    }

    private void UseGravity() {
        if (!_charController.isGrounded) _gravityForce -= 20f * Time.deltaTime;
        else _gravityForce = -0.4f;
    }

    public float GetSpeed() {
        if (Mathf.Abs(_verticalInput) >= Mathf.Abs(_horizontalInput)) {
            return _verticalInput;    
        }
        return _horizontalInput;
    }
}