using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CodeableCookieHolder : CodeableObject
{
    public UnityEvent onTriggerEvent;

    private GameObject heldCookie = null;

    private LineRenderer _antLine;

    protected override void Initialize()
    {
        base.Initialize();

        _antLine = GetComponent<LineRenderer>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (heldCookie == null && collision.gameObject.GetComponent<Cookie>() != null && collision.transform.parent == transform.parent)
        {
            heldCookie = collision.gameObject;
            heldCookie.transform.SetParent(transform, true);
            heldCookie.transform.position = Vector2.zero;

            heldCookie.GetComponent<Collider2D>().enabled = false;

            _antLine.startColor = Color.green;
            _antLine.endColor = Color.green;

            onTriggerEvent?.Invoke();
        }
    }
}
