using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeableLaserHazard : CodeableObject
{
    public LayerMask terrainLayerMask;
    public LayerMask shapeLayerMask;
    public LayerMask hitLayerMask;

    public Color laserColor = Color.green;

    private LineRenderer _lineRenderer;

    protected override void Initialize()
    {
        base.Initialize();

        _lineRenderer = GetComponent<LineRenderer>();
    }

    protected override void UpdateProperties()
    {
        base.UpdateProperties();

        laserColor = (Color)properties["Color Field"];
        _lineRenderer.startColor = laserColor;
        _lineRenderer.endColor = laserColor;
    }

    protected override void PlayActions()
    {
        base.PlayActions();

        RaycastHit2D terrainHit = Physics2D.Raycast(transform.position, transform.up, 200f, terrainLayerMask);
        RaycastHit2D shapeHit;
        RaycastHit2D[] damageHits;
        if (terrainHit)
        {
            shapeHit = Physics2D.Raycast(transform.position, transform.up, terrainHit.distance, shapeLayerMask);
            if (shapeHit && shapeHit.collider.GetComponent<CodeableShape>().color == laserColor)
            {
                _lineRenderer.SetPosition(1, new Vector2(0f, shapeHit.distance) / transform.localScale);
                damageHits = Physics2D.RaycastAll(transform.position, transform.up, shapeHit.distance, hitLayerMask);
            }
            else
            {
                _lineRenderer.SetPosition(1, new Vector2(0f, terrainHit.distance) / transform.localScale);
                damageHits = Physics2D.RaycastAll(transform.position, transform.up, terrainHit.distance, hitLayerMask);
            }
        }
        else
        {
            shapeHit = Physics2D.Raycast(transform.position, transform.up, 200f, shapeLayerMask);
            if (shapeHit && shapeHit.collider.GetComponent<CodeableShape>().color == laserColor)
            {
                _lineRenderer.SetPosition(1, new Vector2(0f, shapeHit.distance) / transform.localScale);
                damageHits = Physics2D.RaycastAll(transform.position, transform.up, shapeHit.distance, hitLayerMask);
            }
            else
            {
                _lineRenderer.SetPosition(1, new(0f, 200f));
                damageHits = Physics2D.RaycastAll(transform.position, transform.up, 200f, hitLayerMask);
            }
        }

        foreach (RaycastHit2D hit in damageHits)
        {
            hit.collider.gameObject.SendMessage("Die");
        }
    }
}
