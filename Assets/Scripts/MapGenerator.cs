using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    // public variables
    public Transform startLocation;

    // private variables
    private List<GameObject> spawnedRooms;
    private int count;
    // Map prefabs
    public List<GameObject> dungeonPrefabs;
    public List<GameObject> townPrefabs;

    


    // Start is called before the first frame update
    void Start()
    {
        spawnedRooms = new List<GameObject>();
        count = 0;
        GameObject temp = dungeonPrefabs[0];
        spawnedRooms.Add(Instantiate(temp, startLocation.position, Quaternion.identity));
        for(int i = 0; i < 4; i++)
        {
            if(i % 2 == 0)
            {
                if(i == 0)
                {
                    spawnedRooms.Add(Instantiate(temp, startLocation.position + new Vector3(16, 0, 0), Quaternion.Euler(0f, 0f, (float) i*90))); //Quaternion.Euler(0f, (float) i*90, 0f)
                }
                else
                {
                    spawnedRooms.Add(Instantiate(temp, startLocation.position + new Vector3(-16, 0, 0), Quaternion.Euler(0f, 0f, (float) i*90))); //Quaternion.Euler(0f, (float) i*90, 0f)
                }
                
            }
            else
            {
                if(i == 1)
                {
                    spawnedRooms.Add(Instantiate(temp, startLocation.position + new Vector3(0, 16, 0), Quaternion.Euler(0f, 0f, (float) i*90))); //Quaternion.Euler(0f, (float) i*90, 0f)
                }
                else
                {
                    spawnedRooms.Add(Instantiate(temp, startLocation.position + new Vector3(0, -16, 0), Quaternion.Euler(0f, 0f, (float) i*90))); //Quaternion.Euler(0f, (float) i*90, 0f)
                }
            }
            
        }
        
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
}
