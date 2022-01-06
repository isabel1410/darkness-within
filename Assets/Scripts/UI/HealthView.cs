using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    public Slider slider;
    public Text healthText;

    public void UpdateView(float currentHealth, float maxHealth)
    {
        slider.value = currentHealth / maxHealth;
        healthText.text = $"{currentHealth} / {maxHealth}";
    }
}
