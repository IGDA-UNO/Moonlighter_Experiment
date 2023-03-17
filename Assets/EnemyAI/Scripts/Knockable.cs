using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Knockable : MonoBehaviour
{

    private Rigidbody2D enemyRB;
    public float ThrustFromKnockback;

    private void Start() {
        enemyRB = this.GetComponent<Rigidbody2D>();
    }
    
    public IEnumerator KnockCoroutine(Rigidbody2D player){
        // print(" starting knock coroutine ");
        Vector2 forceDirection = enemyRB.transform.position - player.transform.position;
        Vector2 force = forceDirection.normalized * ThrustFromKnockback;

        enemyRB.velocity = force;
        yield return new WaitForSeconds(.6f);

        enemyRB.velocity = new Vector2();
    }




}




