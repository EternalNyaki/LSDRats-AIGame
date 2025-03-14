using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIDraggableBlock : UIHoverable
{
    private Vector2 _mouseOffset;

    private Vector3 _initialPosition;

    // Start is called before the first frame update
    protected override void Initialize()
    {
        base.Initialize();

        _initialPosition = transform.position;

        _highlight = GetComponent<Image>();
    }

    public void Reset()
    {

    }

    protected override void OnPointerDown()
    {
        if (GetComponentInParent<UIDropZone>() != null && GetComponentInParent<UIDropZone>().locked) { return; }

        _mouseOffset = transform.position - Input.mousePosition;

        UICursorManager.Instance.OnSelectBlock(this);

        GetComponentInParent<UIDropZone>()?.DetachBlock();
    }

    protected override void OnPointerHold()
    {
        if (GetComponentInParent<UIDropZone>() != null && GetComponentInParent<UIDropZone>().locked) { return; }

        if (UICursorManager.Instance.selectedBlock != this) { return; }

        transform.position = (Vector2)Input.mousePosition + _mouseOffset;
    }

    protected override void OnPointerUp()
    {
        if (GetComponentInParent<UIDropZone>() != null && GetComponentInParent<UIDropZone>().locked) { return; }

        Reset();

        if (UICursorManager.Instance.selectedBlock == this)
        {
            UICursorManager.Instance.OnDeselectBlock();
        }
    }
}
