using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(ChangePersonPlayer))]
public class Player : MonoBehaviour {

    [SerializeField]
    private float _mouseSens;

    [SerializeField]
    private Animator _playerAnimator;

    [SerializeField]
    private UnitStat _stat;

    [SerializeField]
    private HealthUnit _healthUnit;

    [SerializeField]
    private GameObject _trails;

    private CharacterController _characterController;
    private FirstPersonCamera _firstPersonCamera;
    private PlayerAnimations _playerAnimations;
    private ChangePersonPlayer _changePersonPlayer;

    private IMove _movement;

    private void Awake() {
        _stat.Init();
        _characterController = GetComponent<CharacterController>();
        _changePersonPlayer = GetComponent<ChangePersonPlayer>();
        _movement = new PlayerMovement(_characterController, _stat.GetStatByType(StatsType.MoveSpeed));
        _playerAnimations = new PlayerAnimations(_playerAnimator);
        _firstPersonCamera = new FirstPersonCamera(Camera.main.transform, transform, _mouseSens);
        _healthUnit.Init(_stat.GetStatByType(StatsType.Health).currentValue, _stat.GetStatByType(StatsType.Health).startValue);
        _changePersonPlayer.Init(_playerAnimations,_stat);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            _playerAnimations.PlayAttackAnimation();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            _playerAnimations.PlayAttackAnimation2();
        }
        
        _firstPersonCamera.RotateCamera();
        _movement.Move();
        _playerAnimations.SetWalkSpeed(_movement.GetSpeed());
    }
}