using UnityEngine;
using UnityEngine.UI;

public class UIDraggableBlock : UIHoverable
{
    public Color highlightColor;

    private Vector2 _mouseOffset;

    private Vector3 _initialPosition;

    private Image _highlight;

    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = transform.position;

        _highlight = GetComponent<Image>();
    }

    public void Reset()
    {
        transform.position = _initialPosition;
    }

    protected override void OnPointerEnter()
    {
        _highlight.color = highlightColor;
    }

    protected override void OnPointerExit()
    {
        _highlight.color = new(0f, 0f, 0f, 0f);
    }

    public void OnStartDrag()
    {
        _mouseOffset = transform.position - Input.mousePosition;

        UICursorManager.Instance.OnSelectBlock(this);
    }

    public void OnDrag()
    {
        transform.position = (Vector2)Input.mousePosition + _mouseOffset;
    }

    public void OnDrop()
    {
        Reset();

        if (UICursorManager.Instance.selectedBlock == this)
        {
            UICursorManager.Instance.OnDeselectBlock();
        }
    }
}
