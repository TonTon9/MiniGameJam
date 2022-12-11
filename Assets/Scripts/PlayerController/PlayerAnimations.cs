using UnityEngine;

public class PlayerAnimations {

    private Animator _animator;

    public PlayerAnimations(Animator animator) {
        _animator = animator;
    }

    public void ChangeProfile(Animator animator) {
        _animator = animator;
    }
    
    public void SetWalkSpeed(float speed) {
        _animator.SetFloat("Speed", speed);
    }

    public void PlayAttackAnimation() {
        _animator.CrossFade("Attack", 0.2f);
    }
    public void PlayAttackAnimation2() {
        _animator.CrossFade("Strong attack", 0.2f);
    }

    public void PlayDeadAnimation() {
        _animator.CrossFade("Die", 0.1f);
        _animator.CrossFade("Die", 0.1f, 1);
    }
}