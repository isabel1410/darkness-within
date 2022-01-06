using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFactory : MonoBehaviour
{
    public Room startRoom;
    public GameObject createdRoom;

    private Room previousRoom;
    private Stack<Room> roomsToWorkTrough = new Stack<Room>();
    private List<Room> allRooms = new List<Room>();
    private int roomCount = 0;


    void Start()
    {
        Spawn();
        DestroyOverlapped();
    }

    private void Spawn()
    {
        previousRoom = startRoom;
        foreach (SpawnPointInfo spawnPointInfo in startRoom.spawnPoints)
        {  
            Room newRoom = Instantiate(createdRoom.GetComponent<Room>(), spawnPointInfo.transform.position, Quaternion.identity);
            allRooms.Add(newRoom);
            roomCount++;
            newRoom.SetAmountOfExits();
            SpawnPointInfo randomSpawnPoint = newRoom.GetComponent<Room>().spawnPoints[Random.Range(0, previousRoom.GetComponent<Room>().amountOfExits)];
            if (randomSpawnPoint.side != SpawnPoint.NULL)
            {
                for (int i = 0; i <= newRoom.amountOfExits; i++)
                {
                    Room currentRoom = Instantiate(createdRoom.GetComponent<Room>(), randomSpawnPoint.transform.position, Quaternion.identity);
                    allRooms.Add(currentRoom);
                    roomCount++;
                    currentRoom.SetAmountOfExits();
                    currentRoom.DontGoBack(randomSpawnPoint.side);
                    roomsToWorkTrough.Push(currentRoom);
                }
            }
        }

        while (roomsToWorkTrough.Count != 0 && roomCount <= 30)
        {
            SpawnPointInfo randomSpawnPoint = previousRoom.GetComponent<Room>().spawnPoints[Random.Range(0, previousRoom.GetComponent<Room>().amountOfExits)];
            if (randomSpawnPoint.side != SpawnPoint.NULL)
            {
                Room newRoom = roomsToWorkTrough.Pop();
                previousRoom = newRoom;
                for (int i = 0; i <= newRoom.amountOfExits; i++)
                {
                    Room currentRoom = Instantiate(createdRoom.GetComponent<Room>(), randomSpawnPoint.transform.position, Quaternion.identity);
                    allRooms.Add(currentRoom);
                    roomCount++;
                    currentRoom.SetAmountOfExits();
                    currentRoom.DontGoBack(randomSpawnPoint.side);
                    roomsToWorkTrough.Push(currentRoom);
                }
            }
            else
            {
                roomsToWorkTrough.Pop();
            } 
        }
    }

    private void DestroyOverlapped()
    {
        List<Room> roomsToDestroy = new List<Room>();
        List<Room> checkedRooms = new List<Room>();
        foreach (Room room in allRooms)
        {
            checkedRooms.Add(room);
            foreach (Room room1 in allRooms.FindAll(e => e.transform.position == room.transform.position))
            {
                if (room != room1 && !roomsToDestroy.Contains(room1) && !checkedRooms.Contains(room1))
                {
                    roomsToDestroy.Add(room1);
                }
            }
        }
        for (int i = 0; i < roomsToDestroy.Count; i++)
        {
            Destroy(roomsToDestroy[i].gameObject);
        }
    }
}