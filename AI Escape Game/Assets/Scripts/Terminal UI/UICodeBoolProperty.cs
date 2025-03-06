using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICodeBoolProperty : UICodeEnumProperty
{
    public CodeProperties.BoolValue value;

    protected override void Initialize()
    {
        propertyType = CodeProperties.PropertyType.Boolean;

        base.Initialize();
    }
}
