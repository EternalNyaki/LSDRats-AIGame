using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeableSpider : CodeableObject
{
    public float movementStuckTolerance = 0.1f;

    private float speed = 4;
    private Vector2 direction = CodeProperties.FromDirection(CodeProperties.Direction.Horizontal);

    protected override void UpdateProperties()
    {
        base.UpdateProperties();
    }

    public virtual void Move()
    {
        Vector2 temp = transform.position;
        transform.Translate(direction * speed * Time.deltaTime);
        if ((temp - (Vector2)transform.position).magnitude <= movementStuckTolerance * Time.deltaTime)
        {
            direction *= -1;
        }
    }
}
