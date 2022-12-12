using System;
using System.Collections;
using System.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameHud : MonoBehaviour
{
    private const int Time_before_imageLeft_in_milliseconds = 800;
    private const float updateSpeedSec = 0.25f;
    private const float updateLeftSpeedSec = 0.5f;
    
    [Header("Left Up Settings")]
    [SerializeField] private TextMeshProUGUI healthText;

    [SerializeField] private TextMeshProUGUI killResultText;
    [SerializeField] private Image spritePortriet;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image healthBarLeft;
    [SerializeField] private Sprite isGoodBoySprite;
    [SerializeField] private Sprite isEvilBoySprite;
    [SerializeField] private Image ragemodeBar;
    [Header("Other Settings")]
    [SerializeField] private TextMeshProUGUI amountKills;
    
    [SerializeField] private TextMeshProUGUI rageTimeLeft;

    [Header("DeadUI")]
    [SerializeField] private GameObject deadPanel;
    [SerializeField] private GameObject gamePanelUI;

    [SerializeField]
    private TextMeshProUGUI _reloadTime;

    [SerializeField]
    private Image _timeToRageFormReady;

    [SerializeField]
    private TextMeshProUGUI _complexityText;
    
    [SerializeField]
    private TextMeshProUGUI _complexityIncreasedText;
    
    private static float currentStamina;
    private int currentKills;
    private float maxStamina = 100;
    private bool isEvil;
    private float currentValuePct;
    
    private void Awake() {
        SimpleCitizen.OnDie += KillCitizen;
        Policeman.OnDie += KillCitizen;
    }

    public void SetRageTimeLeft(float time) {
        if (time <= 0) {
            if (rageTimeLeft.gameObject.activeSelf) {
                rageTimeLeft.gameObject.SetActive(false);    
            }
            
            return;
        } else {
            if(!rageTimeLeft.gameObject.activeSelf)
                rageTimeLeft.gameObject.SetActive(true);
        }
        rageTimeLeft.text = Math.Round(time).ToString();
    }

    public void IncreaseComplexity(int complexity) {
        _complexityText.text = $"Complexity lvl: {complexity}";
        _complexityIncreasedText.color = Color.white;
        _complexityIncreasedText.transform.localScale = Vector3.zero;
        _complexityIncreasedText.transform.DOScale(1.5f, 2.5f);
        _complexityIncreasedText.DOFade(0, 2.5f);
    }

    public async void UpdateHealth(float currentHealth ,float maxHealth)
    {
        currentValuePct = currentHealth / maxHealth;
        healthText.text = $"{currentHealth.ToString()}%";
        StartCoroutine(ChangeToPct(currentValuePct));
        await Task.Delay(Time_before_imageLeft_in_milliseconds);
        StartCoroutine(ChangeToPctLeft(currentValuePct));
    }

    public void UpdateReloadTimeLeft(float currentTime ,float maxTime) {
        string time = Math.Round(currentTime, 2).ToString();
        if (currentTime > 10) {
            
        }
        if (currentTime < 10) {
            if (time.Length == 1) {
                time = $"{time},00";
            }
            if (time.Length == 3) {
                time = $"{time}0";
            }
        }
        
        _reloadTime.text = time;
        _timeToRageFormReady.fillAmount = currentTime / maxTime;
    }
    
    public void ReadyForAngry() {
        _reloadTime.text = "ready";
    }
    
    private IEnumerator ChangeToPct(float pct) {
        float preChangedPct = healthBar.fillAmount;
        float elapsed = 0f;
        while (elapsed < updateSpeedSec) {
            
            elapsed += Time.deltaTime;
            healthBar.fillAmount = Mathf.Lerp(preChangedPct, pct, elapsed / updateSpeedSec);
            
            //_healthBurImage.color = _colorGradient.Evaluate(_healthBurImage.fillAmount);
            yield return null;
        }
        healthBar.fillAmount = pct;
    }
    
    private IEnumerator ChangeToPctLeft(float pct) {
        float preChangedPct = healthBarLeft.fillAmount;
        float elapsed = 0f;
        while (elapsed < updateLeftSpeedSec) {
            
            elapsed += Time.deltaTime;
            healthBarLeft.fillAmount = Mathf.Lerp(preChangedPct, pct, elapsed / updateLeftSpeedSec);
            
            //_healthBurImage.color = _colorGradient.Evaluate(_healthBurImage.fillAmount);
            yield return null;
        }
        healthBarLeft.fillAmount = pct;
    }
    
    
    private void Start()
    {
        currentStamina = maxStamina;
        currentKills = 0;
    }

    private void Update()
    {
        //StaminaBar();
        Murder();
    }

    private void Murder()
    {
        amountKills.text = "Kills: " + currentKills;
    }
    // public void StaminaBar()
    // {
    //     staminaBar.fillAmount = (float) currentStamina / maxStamina;
    //     staminaText.text = "" + currentStamina + "%";
    // }

    public void Ragemode(float _timeRagemode, float maxTimeRagemode)
    {
        ragemodeBar.fillAmount = (float) _timeRagemode / maxTimeRagemode;
    }
    
    public void KillCitizen() {
        currentKills++;
        killResultText.text = "Kills:         " + currentKills;
    }
    public void TakeStamina(float _stamina)
    {
        currentStamina -= _stamina;
    }

    public void SetAngryProfile() {
        spritePortriet.sprite = isEvilBoySprite;
    }
    
    public void SetPeaceProfile() {
        spritePortriet.sprite = isGoodBoySprite;
    }

    public void ShowDeadScreen() {
        gamePanelUI.SetActive(false);
        deadPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    
    private void OnDestroy() {
        SimpleCitizen.OnDie -= KillCitizen;
        Policeman.OnDie -= KillCitizen;
    }
}
