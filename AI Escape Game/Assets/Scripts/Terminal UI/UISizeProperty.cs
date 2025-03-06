using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISizeProperty : UICodeEnumProperty
{
    public CodeProperties.Size value;

    protected override void Initialize()
    {
        propertyType = CodeProperties.PropertyType.Size;

        base.Initialize();
    }

    public override object GetValue()
    {
        return value;
    }
}
