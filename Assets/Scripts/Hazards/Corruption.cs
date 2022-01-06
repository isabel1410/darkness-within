using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corruption : MonoBehaviour
{
    public delegate void DamagePlayerEvent(float damage);
    public static event DamagePlayerEvent OnDamagePlayer;

    [SerializeField]
    private float damage;
    [SerializeField]
    private float damageCooldown;
    [SerializeField]
    private float attackRange;

    private Transform playerTransform;
    private IEnumerator attackEnumerator;

    protected virtual void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        StartAttack();
    }

    public void StartAttack()
    {
        if (attackEnumerator == null)
        {
            attackEnumerator = Attack();
            StartCoroutine(attackEnumerator);
        }
    }

    public void StopAttack()
    {
        if (attackEnumerator != null)
        {
            StopCoroutine(attackEnumerator);
            attackEnumerator = null;
        }
    }

    private IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(Time.deltaTime);
            if (!InAttackRange())
            {
                continue;
            }
            OnDamagePlayer.Invoke(damage);
            yield return new WaitForSecondsRealtime(damageCooldown);
        }
    }

    private bool InAttackRange()
    {
        return Vector3.Distance(transform.position, playerTransform.transform.position) <= attackRange;
    }
}
