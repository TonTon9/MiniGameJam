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

    [SerializeField]
    private AngryFaceAppear _angryFaceAppear;

    [SerializeField]
    private AudioSource _angrySound;
    
    [SerializeField]
    private AudioSource _peacefullSound;

    [SerializeField]
    private Material _peaceSkyBox;
    
    [SerializeField]
    private Material _anrgySkyBox;

    private PlayerAnimations _playerAnimations;
    private UnitStat _stat;
    private bool _isAngry;

    private ChromaticAberration _chromaticAberration;
    private LensDistortion _lensDistortion;
    private GameHud _gameHud;
    private bool _chromaticAberrationUp;

    public void Init(PlayerAnimations playerAnimations, UnitStat stat, GameHud gameHud) {
        _playerAnimations = playerAnimations;
        _stat = stat;
        _gameHud = gameHud;
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
            _lensDistortion.intensity.value += 20f * Time.deltaTime;
            _chromaticAberration.intensity.value += 4 * Time.deltaTime;
            
            
        } else {
            if (_chromaticAberration.intensity.value <= 0.5f) {
                _chromaticAberrationUp = true;
                return;
            }
            _lensDistortion.intensity.value -= 10f * Time.deltaTime;
            _chromaticAberration.intensity.value -= 2 * Time.deltaTime;
        }
    }

    private void ChangeProfile() {
        _gameHud.SwapPortrait();
        if (_isAngry) {
            RenderSettings.skybox = _peaceSkyBox;
            _peacefullSound.Play();
            _angrySound.Stop();
            _isAngry = false;
            _peacefullProfile.model.SetActive(true);
            _angryProfile.model.SetActive(false);
            ChangeProfileStats(_peacefullProfile);
        } else {
            RenderSettings.skybox = _anrgySkyBox;
            _peacefullSound.Stop();
            _angrySound.Play();
            _angryFaceAppear.ShowAngryFace();
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