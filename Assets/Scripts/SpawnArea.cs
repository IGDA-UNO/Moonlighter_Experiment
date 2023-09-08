using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    public GameObject prefab;
    public BoxCollider2D collider;
    public int numberOfEnemies;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>(); //grabs first collider on parent list

        for(int i = 0; i < numberOfEnemies; i++){
            //what object to instantiate, where to instantiate, how to rotate
            Instantiate(prefab, RandomPointInBox(collider.bounds), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomPointInBox(Bounds bounds){
        //center of collider
        return new Vector3( Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), 1 );

    }
}
