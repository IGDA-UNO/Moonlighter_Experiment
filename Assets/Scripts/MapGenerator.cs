using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    // public variables
    public Transform startLocation;
    [Range(0,100)]
    public int minRooms;
    [Range(0,100)]
    public int maxRooms;

    // private variables
    private List<GameObject> spawnedRooms;
    // Map prefabs
    public List<GameObject> dungeonPrefabs;
    public List<GameObject> townPrefabs;

    


    // Start is called before the first frame update
    void Start()
    {
        spawnedRooms = new List<GameObject>();
        SpawnDungeon(minRooms, maxRooms);
    }

    // Update is called once per frame
    void Update()
    {
        /* if(count == 240)
        {
            spawnedRooms[0].transform.Rotate(new Vector3(0f, 0f, 90f));
            count = 0;
        }
        else
        {
            count++;
        } */
        
    }

    // end 
    public void SpawnDungeon(int minRooms, int maxRooms)
    {
        GameObject temp = dungeonPrefabs[0]; // get starting room prefab
        spawnedRooms.Add(Instantiate(temp, startLocation.position, Quaternion.identity)); // spawn starting room at starting location
        int roomNums = Random.Range(minRooms, maxRooms + 1);
        for(int i = 0; i < roomNums; i++)
        {
            bool isValid = false;
            while (!isValid)
            {
                // select a room to add the new room to
                GameObject r = spawnedRooms[Random.Range(0, spawnedRooms.Count)];
                DungeonRoom dr = r.GetComponent<DungeonRoom>();
                int direction = Random.Range(0,5); // choose a random direction
                Vector3 pos = Vector3.zero;
                switch (direction)
                {
                    case 0:
                        pos = r.transform.position + new Vector3(dr.width, 0, 0);
                        if(!doesOverlap(pos)) // check if the new position overlaps an existing position
                        {
                            // spawn right room and add it to the list of rooms
                            spawnedRooms.Add(Instantiate(temp, pos, Quaternion.identity));
                            isValid = true;
                        }
                        break;
                    case 1:
                        pos = r.transform.position + new Vector3(-dr.width, 0, 0);
                        if(!doesOverlap(pos)) // check if the new position overlaps an existing position
                        {
                            // spawn left room and add it to the list of rooms
                            spawnedRooms.Add(Instantiate(temp, pos, Quaternion.identity));
                            isValid = true;
                        }
                        break;
                    case 2:
                        pos = r.transform.position + new Vector3(0, dr.height, 0);
                        if(!doesOverlap(pos)) // check if the new position overlaps an existing position
                        {
                            // spawn top room and add it to the list of rooms
                            spawnedRooms.Add(Instantiate(temp, pos, Quaternion.identity));
                            isValid = true;
                        }
                        break;
                    case 3:
                        pos = r.transform.position + new Vector3(0, -dr.height, 0);
                        if(!doesOverlap(pos)) // check if the new position overlaps an existing position
                        {
                            // spawn bottom room and add it to the list of rooms
                            spawnedRooms.Add(Instantiate(temp, pos, Quaternion.identity));
                            isValid = true;
                        }
                        break;
                    
                }
            }
        }    
    }

    public bool doesOverlap(Vector3 p) // check if the given transform overlaps any existing transforms
    {
        foreach(GameObject o in spawnedRooms)
        {
            if(Vector3.Distance(p, o.transform.position) < 0.1f)
            {
                return true;
            }
        }

        return false;
    }
}
