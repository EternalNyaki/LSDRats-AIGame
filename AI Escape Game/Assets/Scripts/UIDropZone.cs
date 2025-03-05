using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class UIDropZone : UIHoverable
{
    public UIDraggableBlock defaultBlock;

    public Color highlightColor;

    public UIDraggableBlock heldBlock;

    private Image _highlight;

    // Start is called before the first frame update
    void Start()
    {
        heldBlock = defaultBlock;

        _highlight = GetComponent<Image>();
    }

    protected override void OnPointerEnter()
    {
        _highlight.color = highlightColor;
        UICursorManager.Instance.DeselectBlock += AttachCursorManagerSelectedBlock;
    }

    protected override void OnPointerExit()
    {
        _highlight.color = new(0f, 0f, 0f, 0f);
        UICursorManager.Instance.DeselectBlock -= AttachCursorManagerSelectedBlock;
    }

    private void AttachCursorManagerSelectedBlock()
    {
        AttachBlock(UICursorManager.Instance.selectedBlock);
    }

    private void AttachBlock(UIDraggableBlock block)
    {
        heldBlock = block;
        block.rectTransform.anchoredPosition = rectTransform.anchoredPosition;
    }
}
