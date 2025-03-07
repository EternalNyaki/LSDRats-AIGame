using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CodeableButton : CodeableObject
{
    public UnityEvent onTriggerEvent;

    private LineRenderer _antLine;

    protected override void Initialize()
    {
        base.Initialize();

        _antLine = GetComponent<LineRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shape")
        {
            onTriggerEvent?.Invoke();
            _antLine.startColor = Color.green;
            _antLine.endColor = Color.green;
        }
    }
}
