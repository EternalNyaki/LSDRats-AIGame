using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class UIPropertySlot : UIDropZone
{
    protected override void AttachBlock(UIDraggableBlock block)
    {
        if (block.GetType().IsSubclassOf(typeof(UICodeProperty)))
        {
            base.AttachBlock(block);
        }
    }

    public CodeBlockType GetAttachedCodeType()
    {
        return heldBlock.GetType().GetCustomAttribute<CodeBlockTypeAttribute>().type;
    }

    public object GetAttachedPropertyValue()
    {
        return ((UICodeProperty)heldBlock).GetValue();
    }
}
