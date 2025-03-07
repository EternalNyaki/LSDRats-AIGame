using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class CodeableShape : CodeableObject
{
    public Sprite cubeSprite;
    public Sprite sphereSprite;

    public Color color;

    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb2d;

    protected override void Initialize()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rb2d = GetComponent<Rigidbody2D>();

        base.Initialize();
    }

    protected override void UpdateProperties()
    {
        base.UpdateProperties();

        _spriteRenderer.color = (Color)properties["Color Field"];
        color = _spriteRenderer.color;

        switch ((CodeProperties.Shape)properties["Shape Field"])
        {
            case CodeProperties.Shape.Cube:
                _spriteRenderer.sprite = cubeSprite;
                _rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
                break;

            case CodeProperties.Shape.Sphere:
                _spriteRenderer.sprite = sphereSprite;
                _rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
                break;
        }

        switch ((CodeProperties.Size)properties["Size Field"])
        {
            case CodeProperties.Size.Small:
                transform.localScale = new(0.5f, 0.5f, 0.5f);
                break;

            case CodeProperties.Size.Medium:
                transform.localScale = new(1f, 1f, 1f);
                break;

            case CodeProperties.Size.Large:
                transform.localScale = new(2f, 2f, 2f);
                break;
        }
    }

    void OllisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("Die");
    }
}
