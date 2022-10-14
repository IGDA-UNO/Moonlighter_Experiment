using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState{
    idle,
    walk,
    attack
}
public class TEST_ENEMY : MonoBehaviour
{
    public int health;
    public string enemyName;

    public int baseAttack;

    public int moveSpeed;

    public EnemyState enemyState;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
