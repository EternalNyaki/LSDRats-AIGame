using System;
using UnityEngine;
using UnityEngine.UI;

public class UIDropZone : UIHoverable
{
    public UIDraggableBlock defaultBlock;

    [NonSerialized] public UIDraggableBlock heldBlock;

    // Start is called before the first frame update
    protected override void Initialize()
    {
        base.Initialize();

        if (defaultBlock != null) { defaultBlock.rectTransform.parent = transform; }
        heldBlock = defaultBlock;

        _highlight = GetComponent<Image>();
    }

    protected override void OnPointerEnter()
    {
        base.OnPointerEnter();

        if (heldBlock == null)
        {
            UICursorManager.Instance.DeselectBlock += AttachCursorManagerSelectedBlock;
        }
    }

    protected override void OnPointerExit()
    {
        base.OnPointerExit();

        UICursorManager.Instance.DeselectBlock -= AttachCursorManagerSelectedBlock;
    }

    private void AttachCursorManagerSelectedBlock()
    {
        AttachBlock(UICursorManager.Instance.selectedBlock);
    }

    private void AttachBlock(UIDraggableBlock block)
    {
        heldBlock = block;
        block.rectTransform.SetParent(rectTransform, false);
        block.rectTransform.anchoredPosition = Vector2.zero;
    }

    public void DetachBlock()
    {
        heldBlock.rectTransform.SetParent(rectTransform.parent, true);
        heldBlock = null;
    }
}
