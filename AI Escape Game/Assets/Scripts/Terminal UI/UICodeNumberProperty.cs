using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CodeBlockType(CodeBlockType.NumberProperty)]
public class UICodeNumberProperty : UICodeProperty
{
    public float value;
}