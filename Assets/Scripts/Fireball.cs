using System.Collections;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Direction direction;

    [SerializeField]
    private float maxDistance;

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
            //move
            
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    public enum Direction
    {
        Up,
        UpRight,
        Right,
        DownRight,
        Down,
        DownLeft,
        Left,
        UpLeft
    }
}
