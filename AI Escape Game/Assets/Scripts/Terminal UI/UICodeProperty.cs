using System;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public abstract class UICodeProperty : UICodeBlock
{
    [NonSerialized] public CodeProperties.PropertyType propertyType;
}