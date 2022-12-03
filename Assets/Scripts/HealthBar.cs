using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthHeart;
    int playerhealth, maxHealth;
    public PlayerController attackTarget;

    // Start is called before the first frame update
    void Start()
    {
        attackTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerhealth = attackTarget.getHealth();
        maxHealth = attackTarget.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        playerhealth = attackTarget.getHealth();
        maxHealth = attackTarget.maxHealth;
        healthFill();
    }

    public void healthFill()
    { 
        healthHeart.fillAmount = (float)playerhealth / (float)maxHealth;
        Debug.Log(healthHeart.fillAmount + " -- RATIO: player- " + (float)playerhealth + "max- " + (float)maxHealth);
    }
}
