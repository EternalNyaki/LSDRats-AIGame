using System;
using UnityEngine;
using UnityEngine.UI;

public class UIDropZone : UIHoverable
{
    public UIDraggableBlock defaultBlock;

    public bool locked;

    [NonSerialized] public UIDraggableBlock heldBlock;

    void OnValidate()
    {
        if (heldBlock == null && defaultBlock != null)
        {
            heldBlock = defaultBlock;
        }
    }

    // Start is called before the first frame update
    protected override void Initialize()
    {
        base.Initialize();

        Debug.Log(gameObject.name + "Initialize");

        if (defaultBlock != null)
        {
            heldBlock = defaultBlock;
            defaultBlock.rectTransform.SetParent(rectTransform, false);
            defaultBlock.rectTransform.anchoredPosition = Vector2.zero;
        }
    }

    protected override void OnPointerEnter()
    {
        base.OnPointerEnter();

        if (heldBlock == null && !locked)
        {
            UICursorManager.Instance.DeselectBlock += AttachCursorManagerSelectedBlock;
        }
    }

    protected override void OnPointerExit()
    {
        base.OnPointerExit();

        if (!locked)
        {
            UICursorManager.Instance.DeselectBlock -= AttachCursorManagerSelectedBlock;
        }
    }

    private void AttachCursorManagerSelectedBlock()
    {
        AttachBlock(UICursorManager.Instance.selectedBlock);
    }

    protected virtual void AttachBlock(UIDraggableBlock block)
    {
        if (!locked)
        {
            heldBlock = block;
            block.rectTransform.SetParent(rectTransform, false);
            block.rectTransform.anchoredPosition = Vector2.zero;
        }
    }

    public virtual void DetachBlock()
    {
        if (!locked)
        {
            heldBlock.rectTransform.SetParent(rectTransform.parent, true);
            heldBlock = null;
        }
    }
}
