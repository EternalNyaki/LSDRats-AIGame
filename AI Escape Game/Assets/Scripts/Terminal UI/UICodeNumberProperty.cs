using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CodeBlockType(CodeBlockType.NumberProperty)]
public class UICodeNumberProperty : UICodeProperty
{
    public float value;

    public override object GetValue()
    {
        return value;
    }
}