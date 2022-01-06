using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
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
    private GameObject fireballPrefab;

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
        StartCooldown(cooldownMelee);
        animator.Play("Attack Melee");
    }

    private void AttackRanged()
    {
        StartCooldown(cooldownRanged);
        animator.Play("Attack Ranged");
    }

    private void AttackSpecial()
    {
        StartCooldown(cooldownSpecial);
        animator.Play("Attack Special");
    }

    private IEnumerator StartCooldown(float cooldown)
    {
        readyForAttack = false;
        yield return new WaitForSeconds(cooldown);
        readyForAttack = true;
    }

    private Vector3 GetFireballDirection()
    {
        Vector3 direction = transform.position - Input.mousePosition;
        direction.z = 0;
        return direction;
    }

    public void DamageMelee()//Small box
    {
        //Check which enemies are in range
        List<Enemy> enemies = new List<Enemy>();

        foreach (Enemy enemy in enemies)
        {
            enemy.TakeDamage(damageMelee);
        }
    }

    public void SummonFireBall()
    {
        GameObject fireballObject = Instantiate(fireballPrefab);
        fireballObject.transform.position = transform.position;
        //fireballObject.GetComponent<Fireball>().direction = direction;
    }

    public void SummonFireBallRing()
    {
        Vector3 direction = new Vector3(0, 1, 0);
        for (sbyte counter = 0; counter < 8; counter++)
        {
            GameObject fireballobject = Instantiate(fireballPrefab);
            fireballobject.transform.position = transform.position;
            //fireballobject.GetComponent<Fireball>().direction = direction;
        }
    }
}
