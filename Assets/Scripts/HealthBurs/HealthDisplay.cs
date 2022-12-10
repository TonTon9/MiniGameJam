using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField]
    private Image _healthBurImage;

    [SerializeField]
    private Gradient _colorGradient;
    
    [SerializeField]
    private bool _isNeedToShowHealthDisplay;
    
    private HealthUnit _health;

    public void Init(HealthUnit health, float currentHealth, float maxHealth) {
        if (!_isNeedToShowHealthDisplay) {
            Destroy(gameObject);
            return;
        }
        _health = health;
        _health.OnHealthChange += UpdateHealthBur;
        UpdateHealthBur(currentHealth, maxHealth);
    }

    private void UpdateHealthBur(float currentHealth, float maxHealth) {
        _healthBurImage.fillAmount = currentHealth / maxHealth;
        _healthBurImage.color = _colorGradient.Evaluate(_healthBurImage.fillAmount);
    }
}
