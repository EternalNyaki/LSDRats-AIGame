using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICodeDirectionProperty : UICodeEnumProperty
{
    public CodeProperties.Direction value;

    protected override void Initialize()
    {
        propertyType = CodeProperties.PropertyType.Direction;

        base.Initialize();
    }

    public override object GetValue()
    {
        return value;
    }
}
