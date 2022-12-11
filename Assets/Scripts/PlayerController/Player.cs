using Unity.VisualScripting;
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
    private Transform _cameraHolderTransform;

    [SerializeField]
    private SimpleMeleeAttack _attack;

    [SerializeField]
    private GameHud _gameHud;
    
    private CharacterController _characterController;
    private FirstPersonCamera _firstPersonCamera;
    private PlayerAnimations _playerAnimations;
    private ChangePersonPlayer _changePersonPlayer;

    private IMove _movement;

    private void Awake() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _stat.Init();
        _characterController = GetComponent<CharacterController>();
        _changePersonPlayer = GetComponent<ChangePersonPlayer>();
        _attack.SetDamageStat(_stat.GetStatByType(StatsType.Damage));
        _movement = new PlayerMovement(_characterController, _stat.GetStatByType(StatsType.MoveSpeed));
        _playerAnimations = new PlayerAnimations(_playerAnimator);
        _firstPersonCamera = new FirstPersonCamera(Camera.main.transform, transform,_cameraHolderTransform, _mouseSens);
        _healthUnit.Init(_stat.GetStatByType(StatsType.Health));
        _healthUnit.OnDie += Die;
        _healthUnit.OnHealthChange += _gameHud.UpdateHealth;
        _changePersonPlayer.Init(_playerAnimations,_stat, _gameHud);
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            _playerAnimations.PlayAttackAnimation();
        }
        if (Input.GetMouseButtonDown(1)) {
            _playerAnimations.PlayAttackAnimation2();
        }

        _firstPersonCamera.RotateCamera();
        _movement.Move();
        _playerAnimations.SetWalkSpeed(_movement.GetSpeed());
    }

    private void Die(DamageType damageType) {
        _playerAnimations.PlayDeadAnimation();
        _movement.Stop();
    }
}