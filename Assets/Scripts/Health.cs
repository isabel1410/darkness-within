using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxhealth = 100f;
    public float currenthealth;

    // Start is called before the first frame update
    private void Start()
    {
        currenthealth = maxhealth;
    }

    public void Heal(float amount)
    {
        currenthealth = currenthealth + amount < maxhealth ? maxhealth : currenthealth + amount;
    }

    public void TakeDamage(float damage)
    {
        currenthealth = currenthealth - damage < 0 ? 0 : currenthealth - damage;
    }
}
