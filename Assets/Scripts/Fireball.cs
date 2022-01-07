using System.Collections;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Vector3 direction;
    public float damage;
    public float maxDistance;

    [SerializeField]
    private float speed = 1;

    private Vector3 origin;

    // Start is called before the first frame update
    private void Start()
    {
        origin = transform.position;
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (Vector3.Distance(origin, transform.position) < maxDistance)
        {
            transform.position += direction.normalized * speed / 10;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Evaporate();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            collision.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    private void Evaporate()
    {
        GetComponent<Animator>().Play("Evaporate");
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
