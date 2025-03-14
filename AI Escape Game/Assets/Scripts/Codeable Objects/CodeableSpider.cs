using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeableSpider : CodeableObject
{
    public float movementStuckTolerance = 0.1f;
    public bool isReal = true;

    protected float _speed = 4;
    protected Vector2 _direction = CodeProperties.FromDirection(CodeProperties.Direction.Vertical);

    protected Rigidbody2D _rb2d;

    protected override void Initialize()
    {
        base.Initialize();

        _rb2d = GetComponent<Rigidbody2D>();
    }

    protected override void UpdateProperties()
    {
        base.UpdateProperties();

        if (isReal)
        {
            _speed = (float)properties["Speed Field"];
            _direction = (Vector2)properties["Direction Field"];
        }
    }

    public static void Move(object sender)
    {
        ((CodeableSpider)sender)?.MoveSelf();
    }

    protected virtual void MoveSelf()
    {
        if (isReal)
        {
            if (_rb2d.velocity.magnitude <= movementStuckTolerance * Time.deltaTime)
            {
                _direction *= -1;
            }
            _rb2d.velocity = _direction * _speed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            collision.gameObject.SendMessage("Die");
        }
    }
}
