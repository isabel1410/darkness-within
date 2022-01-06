using UnityEngine;

public class PlayerHealth : Health
{
    public HealthView healthView;
    private Animator animator;

    protected sealed override void Start()
    {
        base.Start();
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
        TakeDamage(damage);
        healthView?.UpdateView(currenthealth);
    }
}
