using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScriptUI : MonoBehaviour
{
    [Header("Left Up Settings")]
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI staminaText;
    // [SerializeField] private TextMeshProUGUI a;
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
    
    private static float currentHealth;
    private static float currentStamina;
    private int currentKills;
    private float maxHealth = 100;
    private float maxStamina = 100;
    private bool isEvil;

    private void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
        currentKills = 0;
    }

    private void Update()
    {
        HealthBar();
        StaminaBar();
        Murder();
        SwapPortriet();
        Test();
        CheckDead();
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

    public void HealthBar()
    {
        healthBar.fillAmount = (float) currentHealth / maxHealth;
        healthText.text = "" + currentHealth + "%";
    }

    public void TakeDamage(float _damageCount)
    {
        if(currentHealth > 0)
        currentHealth -= _damageCount;
    }
    public void Ragemode(float _timeRagemode, float maxTimeRagemode)
    {
        ragemodeBar.fillAmount = (float) _timeRagemode / maxTimeRagemode;
    }
    
    public void TakeKill(int _kill)
    {
        currentKills += _kill;
        ResultGame(currentKills);
    }
    public void TakeStamina(float _stamina)
    {
        currentStamina -= _stamina;
    }
    public void SwapPortriet()
    {
        if (isEvil)
        {
            spritePortriet.sprite = isEvilBoySprite;
        }
        else
        {
            spritePortriet.sprite = isGoodBoySprite;
        }
    }

    public void CheckDead()
    {
        if (currentHealth <= 0)
        {
            gamePanelUI.SetActive(false);
            deadPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ResultGame(int resultKill)
    {
        killResultText.text = "Kills:         " + resultKill;
    }

    public float a;
    public void Test()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            TakeDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.Q) && !isEvil)
        {
            isEvil = true;
        }

        if (Input.GetKeyDown(KeyCode.A) && isEvil)
        {
            isEvil = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            TakeKill(1);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            TakeStamina(2);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            a -= 1f;
            Ragemode(a, 100);
        }
    }
}
