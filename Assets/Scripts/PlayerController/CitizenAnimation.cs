using UnityEngine;

public class CitizenAnimation {
    private Animator _animator;

    public CitizenAnimation(Animator animator) {
        _animator = animator;
    }

    // public void SetWalkSpeed(float verticalSpeed, float horizontalSpeed) {
    //     _animator.SetFloat("Speed", verticalSpeed * _speedParameterMultiplier);
    // }
}