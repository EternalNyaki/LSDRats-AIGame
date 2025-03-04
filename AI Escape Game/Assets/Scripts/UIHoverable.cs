using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHoverable : MonoBehaviour
{
    private bool _wasHovered;

    private RectTransform _rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isHovered = _rectTransform.rect.Contains(Input.mousePosition);

        if (isHovered && !_wasHovered)
        {
            OnPointerEnter();
        }
        else if (!isHovered && _wasHovered)
        {
            OnPointerExit();
        }

        _wasHovered = isHovered;
    }

    protected virtual void OnPointerEnter() { }

    protected virtual void OnPointerExit() { }
}
