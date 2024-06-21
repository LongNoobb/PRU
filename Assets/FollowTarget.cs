using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.RuleTile.TilingRuleOutput;

public class FollowTarget : MonoBehaviour
{

    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 2f;

    protected virtual void FixedUpdate()
    {
        this.Following();
    }

    protected virtual void Following()
    {
        if (this.target == null) return;
        //transform.position = Vector3.Lerp(transform.position, this.target.position, Time.fixedDeltaTime * this.speed);
        transform.position = new Vector3(target.position.x, target.position.y+(float)1.5, target.position.z);
    }

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
}
