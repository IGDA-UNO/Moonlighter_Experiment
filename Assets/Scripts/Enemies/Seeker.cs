using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Enemy
{
    [Range(0f, 20f)]
    public float rotationOffset;
    public Transform debugPoint;

    Vector3 point;

    void Start()
    {
        base.Start();
        ChangeState(EnemyState.PATROL);
        point = debugPoint.position;
    }


    public override void Idle()
    {

    }

    public override void Patrol()
    {
        WalkAround();
    }

    public override void Attack()
    {
        //transform.LookAt(target, Vector3.down);
        LookAtPlayer();
    }

    public void WalkAround()
    {
        Debug.DrawRay(transform.position, point - transform.position, Color.cyan);
        if(Vector3.Distance(transform.position, point) <= rotationOffset)
        {
            transform.RotateAround(point, Vector3.forward, walkSpeed * 10 * Time.deltaTime);
        }
        else
        {
            Move(point, "walk");
        }
    }

    public void LookAtPlayer()
    {
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public override void DamagePlayer()
    {
        throw new System.NotImplementedException();
    }
}
