using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulPoint : MonoBehaviour
{
    public delegate void GetSoulPoints(uint reward);
    public static event GetSoulPoints OnGetSoulPoints;

    [SerializeField]
    private GameObject soulPointPrefab;

    [SerializeField]
    private uint reward;

    public void Start()
    {
        Enemy.OnReleaseSoulPoint += OnReleaseSoulPoint;
    }

    public void OnReleaseSoulPoint(uint soulPointReward, Transform transform)
    {
        reward = soulPointReward;
        Debug.Log(soulPointReward);
        for (int i = 0; i < soulPointReward; i++)
        {
            GameObject soulPoint = Instantiate(soulPointPrefab);
            soulPoint.transform.position = transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnGetSoulPoints?.Invoke(reward);
            for (int i = 0; i < reward; i++)
            {
                Destroy(soulPointPrefab);
            }
        }

    }

}
