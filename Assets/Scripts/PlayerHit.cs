using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.CompareTag("Breakable")){
            Debug.Log("HT!");
            Debug.Log("You just attacked " + other.gameObject.name);
            Destroy(other.gameObject);
        }
    }


}
