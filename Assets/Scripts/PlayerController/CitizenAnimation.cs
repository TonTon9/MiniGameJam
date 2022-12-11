using UnityEngine;

public class CitizenAnimation {
    private Animator _animator;

    public CitizenAnimation(Animator animator) {
        _animator = animator;
    }

    public void PlayDeadAnimation() {
        _animator.CrossFade("Die", 0.1f);
    }

    public void PlayCoolDeadAnimation() {
        _animator.CrossFade("CoolDie", 0.1f);
    }
}