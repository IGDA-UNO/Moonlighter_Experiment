using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Enemy
{
    [Range(0f, 20f)]
    public float rotationOffset;
    public Transform debugPoint;

    Vector3 point;
    Vector3 dashTarget;

    void Start()
    {
        base.Start();
        ChangeState(EnemyState.PATROL);
        dashTarget = Vector3.zero;
        point = debugPoint.position;
    }


    public override void Idle()
    {

    }

    public override void Patrol()
    {
        dashTarget = Vector3.zero;
        WalkAround();
    }

    public override void Attack()
    {
        //transform.LookAt(target, Vector3.forward);
        LookAtPlayer();
        Dash();
    }

    public override void Dies()
    {
        
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

    void Dash()
    {
        Debug.DrawRay(transform.position, dashTarget - transform.position, Color.red);
        if(Vector3.Distance(transform.position, dashTarget) >= .001 && dashTarget != Vector3.zero)
        {
            Move(dashTarget, "run");
        }
        else
        {
            GetDashTarget();
        }
    }

    void GetDashTarget()
    {
        Vector3 vector = target.position - transform.position;
        vector = vector.normalized * 5;
        dashTarget = target.position + vector;
    }
}
