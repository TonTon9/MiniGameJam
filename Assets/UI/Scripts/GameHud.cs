using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameHud : MonoBehaviour
{
    private const float updateSpeedSec = 0.25f;
    private const float updateLeftSpeedSec = 0.5f;
    
    [Header("Left Up Settings")]
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI staminaText;
    
    [SerializeField] private TextMeshProUGUI killResultText;
    [SerializeField] private Image spritePortriet;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image staminaBar;
    [SerializeField] private Sprite isGoodBoySprite;
    [SerializeField] private Sprite isEvilBoySprite;
    [SerializeField] private Image ragemodeBar;
    [Header("Other Settings")]
    [SerializeField] private TextMeshProUGUI amountKills;

    [Header("DeadUI")]
    [SerializeField] private GameObject deadPanel;
    [SerializeField] private GameObject gamePanelUI;
    
    private static float currentStamina;
    private int currentKills;
    private float maxStamina = 100;
    private bool isEvil;
    private float currentValuePct;

    private void Awake() {
        Citizen.OnDie += KillCitizen;
    }

    public void UpdateHealth(float currentHealth ,float maxHealth)
    {
        currentValuePct = currentHealth / maxHealth;
        healthText.text = $"{currentHealth.ToString()}%";
        StartCoroutine(ChangeToPct(currentValuePct));
        // healthBar.fillAmount = currentHealth / maxHealth;
        // healthText.text = "" + currentHealth + "%";
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
    
    
    private void Start()
    {
        currentStamina = maxStamina;
        currentKills = 0;
    }

    private void Update()
    {
        StaminaBar();
        Murder();
    }

    private void Murder()
    {
        amountKills.text = "Kills: " + currentKills;
    }
    public void StaminaBar()
    {
        staminaBar.fillAmount = (float) currentStamina / maxStamina;
        staminaText.text = "" + currentStamina + "%";
    }

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
    public void SwapPortrait()
    {
        if (!isEvil)
        {
            spritePortriet.sprite = isEvilBoySprite;
            isEvil = true;
        }
        else
        {
            spritePortriet.sprite = isGoodBoySprite;
            isEvil = false;
        }
    }

    public void ShowDeadScreen() {
        gamePanelUI.SetActive(false);
        deadPanel.SetActive(true);
        Time.timeScale = 0;
    }
    
    private void OnDestroy() {
        Citizen.OnDie -= KillCitizen;
    }
}
