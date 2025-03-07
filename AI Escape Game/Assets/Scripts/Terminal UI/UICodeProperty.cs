using System;
using UnityEngine;

public abstract class UICodeProperty : UICodeBlock
{
    [NonSerialized] public CodeProperties.PropertyType propertyType;

    public virtual object GetValue() => null;
}