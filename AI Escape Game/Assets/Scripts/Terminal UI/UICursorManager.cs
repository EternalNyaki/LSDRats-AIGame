using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICursorManager : Singleton<UICursorManager>
{
    public UIDraggableBlock selectedBlock { get; private set; }

    public event Action<UIDraggableBlock> SelectBlock;
    public event Action DeselectBlock;

    void Start()
    {
        SelectBlock += SetSelectedBlock;
    }

    private void SetSelectedBlock(UIDraggableBlock block)
    {
        if (selectedBlock != null)
        {
            selectedBlock.Reset();
        }

        selectedBlock = block;
    }

    private void UnlinkSelectedBlock()
    {
        selectedBlock = null;
    }

    public void OnSelectBlock(UIDraggableBlock block)
    {
        SelectBlock?.Invoke(block);
    }

    public void OnDeselectBlock()
    {
        DeselectBlock?.Invoke();

        UnlinkSelectedBlock();
    }
}
