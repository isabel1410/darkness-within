using UnityEngine;

public class SoulPoint : MonoBehaviour
{
    public delegate void GetSoulPoints();
    public static event GetSoulPoints OnGetSoulPoints;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnGetSoulPoints?.Invoke();
            Destroy(gameObject);
        }
    }
}
