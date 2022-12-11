using UnityEngine;

public class CitizenAnimation {
    private Animator _animator;

    public CitizenAnimation(Animator animator) {
        _animator = animator;
    }

    public void SetIsAttackingBool(bool isAttaking) {
        _animator.SetBool("IsAttaking", isAttaking);    
    }
    
    public void SetIsMovingBool(bool isMoving) {
        _animator.SetBool("IsMoving", isMoving);    
    }
    
    public void SetIsTriggeringBool(bool isTriggered) {
        _animator.SetBool("IsTriggered", isTriggered);    
    }

    public void PlayDeadAnimation() {
        _animator.CrossFade("Die", 0.1f);
    }

    public void PlayCoolDeadAnimation() {
        _animator.CrossFade("CoolDie", 0.1f);
    }

    public bool GetAttackBool() {
        return _animator.GetBool("IsAttaking");
    }
}