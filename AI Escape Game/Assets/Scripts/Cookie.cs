using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : InteractableObject
{
    public Vector2 carriedOffset = new Vector2(0f, 1f);

    private Transform holder = null;

    public override void Interact()
    {
        base.Interact();

        if (holder == null)
        {
            holder = _player.transform;
            transform.SetParent(holder, true);
            transform.position = holder.position + (Vector3)carriedOffset;
        }
        else
        {
            transform.SetParent(holder.parent, true);
            holder = null;
        }
    }

    protected override void AfterExit()
    {
        base.AfterExit();

        _player = holder?.GetComponent<PlayerController>();
    }
}
