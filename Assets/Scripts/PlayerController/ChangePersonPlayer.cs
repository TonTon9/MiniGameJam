using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ChangePersonPlayer : MonoBehaviour {
    [SerializeField]
    private PlayerProfile _peacefullProfile;
    
    [SerializeField]
    private PlayerProfile _angryProfile;
    
    [SerializeField]
    private PostProcessVolume _postProcessVolume;

    private PlayerAnimations _playerAnimations;
    private UnitStat _stat;
    private bool _isAngry;

    private ChromaticAberration _chromaticAberration;
    private LensDistortion _lensDistortion;
    private bool _chromaticAberrationUp;

    public void Init(PlayerAnimations playerAnimations, UnitStat stat) {
        _playerAnimations = playerAnimations;
        _stat = stat;
        _chromaticAberration = _angryProfile.postProcessProfile.GetSetting<ChromaticAberration>();
        _lensDistortion = _angryProfile.postProcessProfile.GetSetting<LensDistortion>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            ChangeProfile();
        }

        if (_isAngry) {
            HeadBeatEffect();
        }
    }

    private void HeadBeatEffect() {
        if (_chromaticAberrationUp) {
            if (_chromaticAberration.intensity.value >= 1) {
                _chromaticAberrationUp = false;
                return;
            }
            Debug.Log("+");
            _lensDistortion.intensity.value += 20f * Time.deltaTime;
            _chromaticAberration.intensity.value += 4 * Time.deltaTime;
            
            
        } else {
            if (_chromaticAberration.intensity.value <= 0.5f) {
                _chromaticAberrationUp = true;
                return;
            }
            Debug.Log("-");
            _lensDistortion.intensity.value -= 10f * Time.deltaTime;
            _chromaticAberration.intensity.value -= 2 * Time.deltaTime;
        }
    }

    private void ChangeProfile() {
        if (_isAngry) {
            _isAngry = false;
            _peacefullProfile.model.SetActive(true);
            _angryProfile.model.SetActive(false);
            ChangeProfileStats(_peacefullProfile);
        } else {
            _peacefullProfile.model.SetActive(false);
            _angryProfile.model.SetActive(true);
            ChangeProfileStats(_angryProfile);
            _isAngry = true;
        }
    }

    private void ChangeProfileStats(PlayerProfile profile) {
        _postProcessVolume.profile = profile.postProcessProfile;
        _playerAnimations.ChangeProfile(profile.animator);
        _stat.SetStatValueByType(StatsType.MoveSpeed, profile.moveSpeed);
    }
}