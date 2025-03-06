using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShapeProperty : UICodeEnumProperty
{
    public CodeProperties.Shape value;

    protected override void Initialize()
    {
        propertyType = CodeProperties.PropertyType.Shape;

        base.Initialize();
    }

    public override object GetValue()
    {
        return value;
    }
}
