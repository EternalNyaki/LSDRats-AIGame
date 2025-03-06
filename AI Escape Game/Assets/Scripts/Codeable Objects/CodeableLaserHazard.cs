using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeableLaserHazard : CodeableObject
{
    public LayerMask terrainLayerMask;
    public LayerMask hitLayerMask;

    public Color laserColor = Color.green;

    protected override void PlayActions()
    {
        base.PlayActions();

        RaycastHit2D terrainHit = Physics2D.Raycast(transform.position, transform.up, 30f, terrainLayerMask);
        RaycastHit2D[] damageHits;
        if (terrainHit)
        {
            Debug.DrawLine(transform.position, terrainHit.point, laserColor);
            damageHits = Physics2D.RaycastAll(transform.position, transform.up, terrainHit.distance, hitLayerMask);
        }
        else
        {
            Debug.DrawLine(transform.position, transform.up * 30f + transform.position, laserColor);
            damageHits = Physics2D.RaycastAll(transform.position, transform.up, 30f, hitLayerMask);
        }

        foreach (RaycastHit2D hit in damageHits)
        {
            hit.collider.gameObject.SendMessage("Die");
        }
    }
}
