using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDummy : MonoBehaviour
{
    

    // have reference to slider
    // have health bar max and current
    //when values changed change bar amount
    // have contextmenu that deducts amount from bar

    
    public Slider mSlider;

    public int _CurrentHealth;

    public int CurrentHealth{
        get{
            return _CurrentHealth;
        }
        set{
            _CurrentHealth = value;
            mSlider.value = (float)_CurrentHealth / (float)MaxHealth;
        }


        
    }
    public int MaxHealth;

    public Blinkable blinker;

    private void Start() {
        CurrentHealth = MaxHealth;
    }

    [ContextMenu("Deduct 5 health")]
    public void DeductHealth(){
        CurrentHealth = CurrentHealth - 5;
        if(blinker != null){
            blinker.StartBlinking(0.5f);
        }

    }

    void OnCollisionEnter2D(Collision2D coll){
            // if colliding with player
                // print

            // print(" enemy colliding with something! ");

            if(coll.gameObject.tag == "Enemy"){

                DeductHealth();

                // if (collision.gameObject.CompareTag("Enemy")){
                    Rigidbody2D enemy = coll.gameObject.GetComponent<Rigidbody2D>();
                    if (enemy != null){
                        StartCoroutine(coll.gameObject.GetComponent<Knockable>().KnockCoroutine( this.GetComponent<Rigidbody2D>() ));
                    }
                // }


                // print(" colliding with player! ");
                // print(" about to add force ");
                // GetComponent<Rigidbody2D>().AddForce(new Vector2(-7, 2), ForceMode2D.Impulse);
                // print(" just complete adding to force ");

            }

        }



}
