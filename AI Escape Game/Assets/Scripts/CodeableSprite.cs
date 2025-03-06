using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeableSprite : CodeableObject
{
    private SpriteRenderer _spriteRenderer;

    protected override void Initialize()
    {
        base.Initialize();

        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void UpdateProperties()
    {
        base.UpdateProperties();

        _spriteRenderer.color = (Color)properties["Color Field"];
    }
}
