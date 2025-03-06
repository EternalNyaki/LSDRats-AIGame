using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CodeBlockType
{
    Action,
    NumberProperty,
    EnumProperty
}

public class CodeBlockTypeAttribute : Attribute
{
    public CodeBlockType type;

    public CodeBlockTypeAttribute(CodeBlockType type)
    {
        this.type = type;
    }
}

public abstract class UICodeBlock : UIDraggableBlock
{

}
