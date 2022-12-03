using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spit_Projectile : MonoBehaviour
{
    public float moveSpeed;
    private Transform attackTarget;
    
    // Start is called before the first frame update
    void Start()
    {
        attackTarget = GameObject.FindGameObjectWithTag("Player").transform;
       Invoke("selfDestruct", 4);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.TransformDirection(Vector3.right) * moveSpeed * Time.deltaTime;

    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player" ){
            Debug.Log("Player hit");
            other.GetComponent<PlayerController>().TakeDamage(10);
            Destroy(this.gameObject);
        }
    }
    private void selfDestruct(){
        Destroy(this.gameObject);
    }

   
}
