using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private const int Time_before_imageLeft_in_milliseconds = 800;
    private const float updateSpeedSec = 0.25f;
    private const float updateLeftSpeedSec = 0.5f;
    
    [SerializeField]
    private Image _healthBurImage;
    
    [SerializeField]
    private Image _healthBurImageLeft;

    [SerializeField]
    private Gradient _colorGradient;
    
    [SerializeField]
    private bool _isNeedToShowHealthDisplay;

    private HealthUnit _health;
    private float currentValuePct;

    public void Init(HealthUnit health, float currentHealth, float maxHealth) {
        if (!_isNeedToShowHealthDisplay) {
            Destroy(gameObject);
            return;
        }
        _health = health;
        _health.OnHealthChange += UpdateHealthBur;
        UpdateHealthBur(currentHealth, maxHealth);
    }

    private async void UpdateHealthBur(float currentHealth, float maxHealth) {
        // _healthBurImage.fillAmount = currentHealth / maxHealth;
        
        
        currentValuePct = currentHealth / maxHealth;
        StartCoroutine(ChangeToPct(currentValuePct));
        await Task.Delay(Time_before_imageLeft_in_milliseconds);
        StartCoroutine(ChangeToPctLeft(currentValuePct));

    }

    private IEnumerator ChangeToPct(float pct) {
        float preChangedPct = _healthBurImage.fillAmount;
        float elapsed = 0f;
        while (elapsed < updateSpeedSec) {
            elapsed += Time.deltaTime;
            _healthBurImage.fillAmount = Mathf.Lerp(preChangedPct, pct, elapsed / updateSpeedSec);
            _healthBurImage.color = _colorGradient.Evaluate(_healthBurImage.fillAmount);
            yield return null;
        }
        _healthBurImage.fillAmount = pct;
    }
        
    private IEnumerator ChangeToPctLeft(float pct) {
        float preChangedPct = _healthBurImageLeft.fillAmount;
        float elapsed = 0f;
        while (elapsed < updateLeftSpeedSec) {
            elapsed += Time.deltaTime;
            _healthBurImageLeft.fillAmount = Mathf.Lerp(preChangedPct, pct, elapsed / updateSpeedSec);
            yield return null;
        }
        _healthBurImageLeft.fillAmount = pct;
    }

    
    
}