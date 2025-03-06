using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICodeColorProperty : UICodeEnumProperty
{
    public CodeProperties.ColorValue value;

    protected override void Initialize()
    {
        propertyType = CodeProperties.PropertyType.Color;

        base.Initialize();
    }
}
