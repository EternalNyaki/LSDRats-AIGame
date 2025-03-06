using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorSquare : CodableObject
{
    private SpriteRenderer _spriteRenderer;

    protected override void Initialize()
    {
        base.Initialize();

        _spriteRenderer = GetComponent<SpriteRenderer>();

        _actionsList.Add(DrawSquare);

        _propertiesList.Add("Color", _spriteRenderer.color);
    }

    // protected override void LoadActions()
    // {
    //     base.LoadActions();

    //     if (_propertiesList == null) { return; }

    //     GetEditableCodeFromTerminal(out List<CustomizableProperty> properties, out List<UnityEvent> actions);

    //     if (_propertiesList.ContainsKey("Color"))
    //     {
    //         _propertiesList.Remove("Color");
    //     }
    //     _propertiesList.Add("Color", (CustomizableProperty<Color>)properties[0]);
    // }

    public void DrawSquare()
    {
        _propertiesList.TryGetValue("Color", out object color);
        try
        {
            _spriteRenderer.color = (Color)color;
        }
        catch (InvalidCastException e)
        {

        }
    }
}
