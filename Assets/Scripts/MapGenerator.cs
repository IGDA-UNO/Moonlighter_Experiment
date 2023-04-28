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
    private List<DungeonRoom> spawnedRooms;
    // Map prefabs
    public List<GameObject> dungeonPrefabs;
    public List<GameObject> townPrefabs;

    


    // Start is called before the first frame update
    void Start()
    {
        spawnedRooms = new List<DungeonRoom>();
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
        GameObject temp = Instantiate(dungeonPrefabs[0], startLocation.position, Quaternion.identity);
        spawnedRooms.Add(temp.GetComponent<DungeonRoom>()); // spawn starting room at starting location
        int roomNums = Random.Range(minRooms, maxRooms + 1);
        for(int i = 0; i < roomNums; i++)
        {
            List<DungeonRoom> openRooms = spawnedRooms.FindAll(d => !d.isFull()); // get all the rooms with open exits
            DungeonRoom dr = openRooms[Random.Range(0, openRooms.Count)]; // select a room to add the new room to
            // setup directional offests
            Vector3 right = dr.gameObject.transform.position + new Vector3(dr.width, 0, 0);
            Vector3 left = dr.gameObject.transform.position + new Vector3(-dr.width, 0, 0);
            Vector3 top = dr.gameObject.transform.position + new Vector3(0, dr.height, 0);
            Vector3 bottom = dr.gameObject.transform.position + new Vector3(0, -dr.height, 0);

            if (dr.hasRightExit && !doesOverlap(right)) // start with the right exit
            {
                CreateRoom(dr, right, "right");
            }
            else if (dr.hasLeftExit && !doesOverlap(left)) // then try the Left
            {
                CreateRoom(dr, left, "left");
            }
            else if (dr.hasTopExit && !doesOverlap(top)) // then try the top
            {
                CreateRoom(dr, top, "top");
            }
            else if (dr.hasBottomExit && !doesOverlap(bottom)) // then try the bot
            {
                CreateRoom(dr, bottom, "bottom");
            }
            else
            {
                Debug.Log($"[MapGenerator] DungeonRoom ({dr.gameObject.transform.position.x/16}, {dr.gameObject.transform.position.y/16}) has [{dr.hasRightExit}, {dr.hasLeftExit}, {dr.hasTopExit}, {dr.hasBottomExit}], but they are blocked");
            }
        }    
    }

    private void CreateRoom(DungeonRoom original, Vector3 pos, string dir)
    {
        List<GameObject> openDir = new List<GameObject>();
        switch (dir) // find the room prefabs that have the appropriate exit for the given direction
        {
            case "right":
                openDir = dungeonPrefabs.FindAll(d => d.GetComponent<DungeonRoom>().hasLeftExit);
                break;
            case "left":
                openDir = dungeonPrefabs.FindAll(d => d.GetComponent<DungeonRoom>().hasRightExit);
                break;
            case "top":
                openDir = dungeonPrefabs.FindAll(d => d.GetComponent<DungeonRoom>().hasBottomExit);
                break;
            case "bottom":
                openDir = dungeonPrefabs.FindAll(d => d.GetComponent<DungeonRoom>().hasTopExit);
                break;
        }

        GameObject temp = Instantiate(openDir[Random.Range(0, openDir.Count)], pos, Quaternion.identity); // spawn a random room from the list
        DungeonRoom room = temp.GetComponent<DungeonRoom>(); // get the DungeonRoom object
        original.AddExit(dir); // make the given direction taken for the original room
        switch (dir) // set the opposite direction as taken for the new room
        {
            case "right":
                room.AddExit("left");
                break;
            case "left":
                room.AddExit("right");
                break;
            case "top":
                room.AddExit("bottom");
                break;
            case "bottom":
                room.AddExit("top");
                break;
        }

        spawnedRooms.Add(room); // add the new room to the list of rooms
    }

    public bool doesOverlap(Vector3 p) // check if the given transform overlaps any existing transforms
    {
        foreach(DungeonRoom d in spawnedRooms)
        {
            if(Vector3.Distance(p, d.gameObject.transform.position) < 0.1f)
            {
                return true;
            }
        }

        return false;
    }
}
