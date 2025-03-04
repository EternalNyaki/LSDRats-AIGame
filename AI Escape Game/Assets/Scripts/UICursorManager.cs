using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICursorManager : Singleton<UICursorManager>
{
    public UIDraggableBlock selectedBlock { get; private set; }

    public void SetSelectedBlock(UIDraggableBlock block)
    {
        if (selectedBlock != null)
        {
            selectedBlock.Reset();
        }

        selectedBlock = block;
    }
}
