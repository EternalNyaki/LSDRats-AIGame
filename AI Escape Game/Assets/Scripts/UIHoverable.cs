using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHoverable : MonoBehaviour
{
    protected bool _isHovered;
    protected bool _wasHovered;

    public RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _isHovered = RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition);

        if (_isHovered && !_wasHovered)
        {
            OnPointerEnter();
        }
        else if (!_isHovered && _wasHovered)
        {
            OnPointerExit();
        }

        if (_isHovered && Input.GetMouseButtonDown(0))
        {
            OnPointerDown();
        }
        else if (_isHovered && Input.GetMouseButtonUp(0))
        {
            OnPointerUp();
        }

        _wasHovered = _isHovered;
    }

    protected virtual void OnPointerEnter() { }
    protected virtual void OnPointerExit() { }
    protected virtual void OnPointerDown() { }
    protected virtual void OnPointerUp() { }
}
