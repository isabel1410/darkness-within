using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public delegate void DamagePlayerEvent(float damage);
    public static event DamagePlayerEvent OnDamagePlayer;

    public delegate void ReleaseSoulPoints(uint currentAmountOfSoulPoints, Transform transform);
    public static event ReleaseSoulPoints OnReleaseSoulPoint;

    [SerializeField]
    private Health health;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float damageCooldown;
    [SerializeField]
    private float movementDistance;
    [SerializeField]
    private float attackRange;
    [SerializeField]
    private uint soulPointReward;
    [SerializeField]
    private uint minSoulPointReward;
    [SerializeField]
    private uint maxSoulPointReward;



    private Animator animator;
    private Transform playerTransform;
    private IEnumerator movementEnumerator;
    private IEnumerator attackEnumerator;
    private bool isDead;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        soulPointReward = (uint)Random.Range(minSoulPointReward, maxSoulPointReward);
    }

    public virtual void TakeDamage(float damage)
    {
        health.TakeDamage(damage);
        isDead = health.currenthealth == 0;
        if (isDead)
        {
            Die();
        }
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

    public virtual void StartMovement()
    {
        if (movementEnumerator == null)
        {
            movementEnumerator = MoveTowardsPlayer();
            StartCoroutine(movementEnumerator);
        }
    }

    public void StopMovement()
    {
        if (movementEnumerator != null)
        {
            StopCoroutine(movementEnumerator);
            movementEnumerator = null;
        }
    }


    private void Die()
    {
        StopMovement();
        GetComponent<Collider2D>().enabled = false;
        if (animator != null)
        {
            animator.Play("Die");
        }

        Debug.Log("Slime died", gameObject);
    }

    private IEnumerator MoveTowardsPlayer()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(Time.deltaTime);
            if (Vector3.Distance(transform.position, playerTransform.transform.position) < movementDistance)
            {
                continue;
            }
            Vector3 movement = (playerTransform.transform.position - transform.position).normalized * movementSpeed / 100;
            transform.position += movement;
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
            if (animator)
            {
                animator.Play("Attack");
            }
            yield return new WaitForSecondsRealtime(damageCooldown);
        }
    }

    public void DamagePlayer()
    {
        if (InAttackRange())
        {
            OnDamagePlayer.Invoke(damage);
        }
    }

    public void SoulPointReleases()
    {
        OnReleaseSoulPoint?.Invoke(soulPointReward, transform);
    }

    private bool InAttackRange()
    {
        return Vector3.Distance(transform.position, playerTransform.transform.position) <= attackRange;
    }
}