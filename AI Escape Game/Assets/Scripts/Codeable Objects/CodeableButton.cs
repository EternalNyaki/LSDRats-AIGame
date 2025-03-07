using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CodeableButton : CodeableObject
{
    public UnityEvent onTriggerEvent;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shape")
        {
            onTriggerEvent?.Invoke();
        }
    }
}
