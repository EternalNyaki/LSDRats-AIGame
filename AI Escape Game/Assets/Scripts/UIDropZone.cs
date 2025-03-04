using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class UIDropZone : UIHoverable
{
    public UIDraggableBlock defaultBlock;

    public Color highlightColor;

    public UIDraggableBlock HeldBlock
    {
        get { return _heldBlock; }
        set
        {
            _heldBlock = value;
            OnBlockChanged(_heldBlock);
        }
    }
    private UIDraggableBlock _heldBlock;

    public event EventHandler<UIDraggableBlock> BlockChanged;

    private Image _highlight;

    // Start is called before the first frame update
    void Start()
    {
        BlockChanged += AttachBlock;

        _heldBlock = defaultBlock;

        _highlight = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerUp()
    {
        Debug.Log($"I am holding a block: {_heldBlock != null} \n The cursor has selected a block: {UICursorManager.Instance.selectedBlock != null}");
        if (_heldBlock == null && UICursorManager.Instance.selectedBlock != null)
        {
            OnBlockChanged(UICursorManager.Instance.selectedBlock);
        }
    }

    protected override void OnPointerEnter()
    {
        _highlight.color = highlightColor;
    }

    protected override void OnPointerExit()
    {
        _highlight.color = new(0f, 0f, 0f, 0f);
    }

    private void AttachBlock(object sender, UIDraggableBlock block)
    {
        HeldBlock = block;
        _heldBlock.transform.parent = transform;
        _heldBlock.transform.localPosition = Vector3.zero;
    }

    private void OnBlockChanged(UIDraggableBlock block)
    {
        BlockChanged?.Invoke(this, block);
    }
}
