using System.Collections;
using UnityEngine;

public class CorruptionPuddle : Corruption
{
    [SerializeField]
    private float lifeSpan;

    protected sealed override void Start()
    {
        base.Start();
        if (lifeSpan != -1)
        {
            StartCoroutine(DestroyAfterTime(lifeSpan));
        }
    }

    private IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
