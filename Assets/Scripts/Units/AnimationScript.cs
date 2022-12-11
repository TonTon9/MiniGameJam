using UnityEngine;

public class AnimationScript : MonoBehaviour {
    [SerializeField]
    private GameObject _deadBloodEffect;

    [SerializeField]
    private Transform _bloodPose1;
    
    [SerializeField]
    private Transform _coolBloodPose;
    
    private void PlayDeadBloodEffect() {
        var effect = Instantiate(_deadBloodEffect, _bloodPose1.position, Quaternion.identity);
        Destroy(effect, 6f);
    }

    private void PlayCoolDeadBloodEffect() {
        var effect = Instantiate(_deadBloodEffect, _coolBloodPose.position, Quaternion.identity);
        Destroy(effect, 6f);
    }
}