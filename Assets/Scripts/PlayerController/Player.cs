using System;
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
    
    [SerializeField]
    private float _reloadRageFormBase;

    private float _reloadRageFormTimeLeft;

    [SerializeField]
    private float _rageFormDuration;
    private float _rageTimeLeft;
    
    
    private bool isDead;
    
    private CharacterController _characterController;
    private FirstPersonCamera _firstPersonCamera;
    private PlayerAnimations _playerAnimations;
    private ChangePersonPlayer _changePersonPlayer;

    private IMove _movement;

    private void Awake() {
        _reloadRageFormTimeLeft = _reloadRageFormBase;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _stat.Init();
        _characterController = GetComponent<CharacterController>();
        _changePersonPlayer = GetComponent<ChangePersonPlayer>();
        _attack.SetDamageStat(_stat.GetStatByType(StatsType.Damage));
        _attack.OnAttack += _healthUnit.HealByAttack;
        _movement = new PlayerMovement(_characterController, _stat.GetStatByType(StatsType.MoveSpeed));
        _playerAnimations = new PlayerAnimations(_playerAnimator);
        _firstPersonCamera = new FirstPersonCamera(Camera.main.transform, transform,_cameraHolderTransform, _mouseSens);
        _healthUnit.Init(_stat.GetStatByType(StatsType.Health));
        _healthUnit.OnDie += Die;
        _healthUnit.OnHealthChange += _gameHud.UpdateHealth;
        _changePersonPlayer.Init(_playerAnimations,_stat, _gameHud);
    }


    private void Update() {
        if(isDead) return;
        if (Input.GetMouseButtonDown(0)) {
            _playerAnimations.PlayAttackAnimation();
        }
        if (Input.GetMouseButtonDown(1)) {
            _playerAnimations.PlayAttackAnimation2();
        }
        if (Input.GetKeyDown(KeyCode.R) && _reloadRageFormTimeLeft >= _reloadRageFormBase && !_changePersonPlayer._isAngry) {
            ChangeProfileToRage();
        }
        if (_changePersonPlayer._isAngry) {
            RageFormLeft();
        } else {
            if (_reloadRageFormTimeLeft > _reloadRageFormBase) {
                _reloadRageFormTimeLeft = _reloadRageFormBase;
                return;
            }
            _reloadRageFormTimeLeft += Time.deltaTime;
            Debug.Log(_reloadRageFormTimeLeft);
            _gameHud.UpdateReloadTimeLeft(_reloadRageFormTimeLeft, _reloadRageFormBase);
        }
        

        _firstPersonCamera.RotateCamera();
        _movement.Move();
        _playerAnimations.SetWalkSpeed(_movement.GetSpeed());
    }


    private void RageFormLeft() {
        if (_rageTimeLeft <= 0) {
            PeaceProfile();
        } else {
            _gameHud.SetRageTimeLeft(_rageTimeLeft);
            _rageTimeLeft -= Time.deltaTime;
        }
    }

    private void PeaceProfile() {
        _reloadRageFormTimeLeft = 0;
        _gameHud.UpdateReloadTimeLeft(_reloadRageFormTimeLeft, _reloadRageFormBase);
        _gameHud.SetRageTimeLeft(0);
        _changePersonPlayer.PeaceProfile();
    }

    private void ChangeProfileToRage() {
        _rageTimeLeft = _rageFormDuration;
        _changePersonPlayer.RageProfile();
    }

    private void Die(DamageType damageType) {
        _attack.OnAttack -= _healthUnit.HealByAttack;
        _changePersonPlayer.ChangeProfileOnDead();
        _gameHud.ShowDeadScreen();
        isDead = true;
        _playerAnimations.PlayDeadAnimation();
        _movement.Stop();
    }
}