using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapComponent : MapComponent
{
    protected bool isActive;

    private void Update()
    {
        if(isActive)
        {
            OnActivate();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("AI"))
        {
            ApplyEffect();
        }
    }

    virtual protected void ApplyEffect()
    {

    }

    virtual protected void OnActivate()
    {

    }
}
