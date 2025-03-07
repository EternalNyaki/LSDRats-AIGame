using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CodeableHungrySpider : CodeableSpider
{
    public LayerMask cookieLayerMask;

    private Cookie cookie;

    private NavMeshAgent _agent;

    protected override void UpdateProperties()
    {
        base.UpdateProperties();

        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;

        cookie = Physics2D.OverlapCircle(transform.position, 100f, cookieLayerMask)?.GetComponent<Cookie>();
    }

    protected override void MoveSelf()
    {
        if (cookie == null)
        {
            //vibrate?
        }
        else
        {
            _agent.SetDestination(cookie.transform.position);
        }
    }
}
