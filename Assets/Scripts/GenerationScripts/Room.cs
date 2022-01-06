using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public int amountOfExits;

    public SpawnPointInfo[] spawnPoints = new SpawnPointInfo[4];

    public GameObject otherRoom;
    public bool startroom = false;

    public void NotASpawnPoint(SpawnPoint Side)
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (spawnPoints[i].side == Side)
            {
                spawnPoints[i].side = SpawnPoint.NULL;
            }
        }
    }

    public void DontGoBack(SpawnPoint Side)
    {
        if (Side == SpawnPoint.East)
        {
            NotASpawnPoint(SpawnPoint.West);
        }
        else if (Side == SpawnPoint.West)
        {
            NotASpawnPoint(SpawnPoint.East);
        }
        else if (Side == SpawnPoint.North)
        {
            NotASpawnPoint(SpawnPoint.South);
        }
        else
        {
            NotASpawnPoint(SpawnPoint.North);
        }
    }

    public int SetAmountOfExits()
    {
        amountOfExits = Random.Range(1, 4);
        return amountOfExits;
    }
}
