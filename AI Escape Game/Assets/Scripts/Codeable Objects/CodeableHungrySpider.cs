using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CodeableHungrySpider : CodeableSpider
{
    public LayerMask cookieLayerMask;

    private Cookie cookie;

    private NavMeshAgent _agent;

    protected override void Initialize()
    {
        base.Initialize();

        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    void OnDisable()
    {
        _agent.enabled = false;
    }

    protected override void UpdateProperties()
    {
        _agent.enabled = true;
    }

    protected override void MoveSelf()
    {
        if (cookie == null)
        {
            cookie = Physics2D.OverlapCircle(transform.position, 7f, cookieLayerMask)?.GetComponent<Cookie>();
        }
        else
        {
            _agent.SetDestination(cookie.transform.position);
        }
    }
}
