using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public Canvas parentCanvas;

    [SerializeField]
    private float damageMelee;
    [SerializeField]
    private float damageRanged;
    [SerializeField]
    private float damageSpecial;
    [SerializeField]
    private float cooldownMelee;
    [SerializeField]
    private float cooldownRanged;
    [SerializeField]
    private float cooldownSpecial;
    [SerializeField]
    private float rangeMeleeFront;
    [SerializeField]
    private float rangeMeleeSide;
    [SerializeField]
    private float rangeRanged;
    [SerializeField]
    private float rangeSpecial;
    [SerializeField]
    private GameObject fireballPrefab;
    [SerializeField]
    private new Camera camera;

    private Animator animator;
    private bool readyForAttack;

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
        readyForAttack = true;
        PlayerInputProcessor.OnAttackMelee += AttackMelee;
        PlayerInputProcessor.OnAttackRanged += AttackRanged;
        PlayerInputProcessor.OnAttackSpecial += AttackSpecial;
    }

    private void AttackMelee()
    {
        if (!readyForAttack)
        {
            return;
        }
        StartCoroutine(StartCooldown(cooldownMelee));
        animator.Play("Attack Melee");
    }

    private void AttackRanged()
    {
        if (!readyForAttack)
        {
            return;
        }
        StartCoroutine(StartCooldown(cooldownRanged));
        animator.Play("Attack Ranged");
    }

    private void AttackSpecial()
    {
        if (!readyForAttack)
        {
            return;
        }
        StartCoroutine(StartCooldown(cooldownSpecial));
        animator.Play("Attack Special");
    }

    private IEnumerator StartCooldown(float cooldown)
    {
        readyForAttack = false;
        yield return new WaitForSeconds(cooldown);
        readyForAttack = true;
    }

    private Vector3 GetDirection()
    {
        Vector3 direction = camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction.z = 0;
        return direction - transform.position;
    }

    public void DamageMelee()//Small box
    {
        Vector3 direction = GetDirection();
        RaycastHit[] raycastHits = Physics.BoxCastAll(transform.position, new Vector3(rangeMeleeSide / 2, rangeMeleeSide / 2, .5f), direction, transform.rotation, rangeMeleeFront);
        foreach (RaycastHit raycastHit in raycastHits)
        {
            if (raycastHit.collider.gameObject.GetComponent<Enemy>())
            {
                raycastHit.collider.gameObject.GetComponent<Enemy>().TakeDamage(damageMelee);
            }
        }
    }

    public void SummonFireBall()
    {
        GameObject fireballObject = Instantiate(fireballPrefab);
        Fireball fireball = fireballObject.GetComponent<Fireball>();
        fireballObject.transform.position = transform.position;
        fireball.direction = GetDirection();
        fireball.damage = damageRanged;
        fireball.maxDistance = rangeRanged;
    }

    public void SummonFireBallRing()
    {
        Vector3[] directions =
        {
            new Vector3(0, 1, 0),//Up
            new Vector3(.5f, .5f, 0),
            new Vector3(1, 0, 0),//Right
            new Vector3(.5f, -.5f, 0),
            new Vector3(0, -1, 0),//Down
            new Vector3(-.5f, -.5f, 0),
            new Vector3(-1, 0, 0),//Left
            new Vector3(-.5f, .5f, 0)
        };
        for (sbyte counter = 0; counter < 8; counter++)
        {
            GameObject fireballObject = Instantiate(fireballPrefab);
            Fireball fireball = fireballObject.GetComponent<Fireball>();
            fireballObject.transform.position = transform.position;
            fireball.direction = directions[counter];
            fireball.damage = damageSpecial;
            fireball.maxDistance = rangeSpecial;
        }
    }
}
