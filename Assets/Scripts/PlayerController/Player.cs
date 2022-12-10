using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour {

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _mouseSens;

    [SerializeField]
    private Animator _playerAnimator;
    
    private CharacterController _characterController;
    private FirstPersonCamera _firstPersonCamera;
    private PlayerAnimations _playerAnimations;
    
    private IMove _movement;

    private void Awake() {
        _characterController = GetComponent<CharacterController>();
        _movement = new PlayerMovement(_characterController, _speed);
        _playerAnimations = new PlayerAnimations(_playerAnimator);
        _firstPersonCamera = new FirstPersonCamera(Camera.main.transform, transform, _mouseSens);
    }

    private void Update() {
        _firstPersonCamera.RotateCamera();
        _movement.Move();
        _playerAnimations.SetWalkSpeed(_movement.GetVerticalSpeed(), _movement.GetHorizontalSpeed());
    }
}