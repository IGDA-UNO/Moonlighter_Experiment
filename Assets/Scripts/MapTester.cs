using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTester : MonoBehaviour
{

    public Collider2D smasherSpawn;
    public Collider2D spitterSpawn;
    public Collider2D seekerSpawn;
    public GameObject smasherPrefab;
    public GameObject spitterPrefab;
    public GameObject seekerPrefab;
    [Range(0, 10)]
    public int spawnNumber;

    private List<GameObject> smasherPreload;
    private List<GameObject> spitterPreload;
    private List<GameObject> seekerPreload;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 loc = new Vector3(1000, 1000, 1);
        for(int p = 0; p < 10; p++)
        {
            GameObject sm = Instantiate(smasherPrefab, loc, Quaternion.identity);
            GameObject sp = Instantiate(spitterPrefab, loc, Quaternion.identity);
            GameObject se = Instantiate(seekerPrefab, loc, Quaternion.identity);
            sm.SetActive(false);
            sp.SetActive(false);
            se.SetActive(false);
            smasherPreload.Add(sm);
            spitterPreload.Add(sp);
            seekerPreload.Add(se);
        }


        for(int x = 0; x < spawnNumber; x++)
        {
            SpawnMonster("smasher");
            SpawnMonster("spitter");
            SpawnMonster("seeker");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnMonster(string type)
    {
        Vector3 spawn;
        switch (type)
        {
            case "smasher":
                spawn = new Vector3(Random.Range(smasherSpawn.bounds.min.x, smasherSpawn.bounds.max.x), Random.Range(smasherSpawn.bounds.min.y, smasherSpawn.bounds.max.y), 1);
                
                break;
            case "spitter":
                spawn = new Vector3(Random.Range(spitterSpawn.bounds.min.x, spitterSpawn.bounds.max.x), Random.Range(spitterSpawn.bounds.min.y, spitterSpawn.bounds.max.y), 1);

                break;
            case "seeker":
                spawn = new Vector3(Random.Range(seekerSpawn.bounds.min.x, seekerSpawn.bounds.max.x), Random.Range(seekerSpawn.bounds.min.y, seekerSpawn.bounds.max.y), 1);

                break;
        }
           
    }

    private GameObject NextPrefab(string type)
    {
        switch (type)
        {
            case "smasher":
                return GrabPrefab(smasherPreload);
            case "spitter":
                return GrabPrefab(spitterPreload);
            case "seeker":
                return GrabPrefab(seekerPreload);
            default:
                return null;
        }
    }

    private GameObject GrabPrefab(List<GameObject> p)
    {
        for(int i = 0; i < p.Count; i++)
        {
            if(!p[i].activeInHierarchy)
            {
                return p[i];
            }
        }

        return null;
    }
}
