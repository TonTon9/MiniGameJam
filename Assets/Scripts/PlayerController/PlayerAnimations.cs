using UnityEngine;

public class PlayerAnimations {

    private Animator _animator;
    
    public PlayerAnimations(Animator animator) {
        _animator = animator;
    }
    
    public void SetWalkSpeed(float verticalSpeed ,float horizontalSpeed ) {
        _animator.SetFloat("Speed", verticalSpeed);
    }
}