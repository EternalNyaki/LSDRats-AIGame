using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIActionSlot : UIDropZone
{
    protected override void AttachBlock(UIDraggableBlock block)
    {
        if (block.GetType() == typeof(UICodeAction) || block.GetType().IsSubclassOf(typeof(UICodeAction)))
        {
            base.AttachBlock(block);
        }
    }

    public Action GetAttachedAction()
    {
        return ((UICodeAction)heldBlock).value;
    }
}
