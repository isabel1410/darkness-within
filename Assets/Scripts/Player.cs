using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;

    public void Start()
    {
        Enemy.OnDamagePlayer += OnDamagePlayer;
        Corruption.OnDamagePlayer += OnDamagePlayer;
        animator = GetComponent<Animator>();
    }

    public void OnDamagePlayer(float damage)
    {
        if (animator != null)
        {
            animator.Play("Take Damage");
        }
        GetComponent<Health>().TakeDamage(damage);
    }
}
