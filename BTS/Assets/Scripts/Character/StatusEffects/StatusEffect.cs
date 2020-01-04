using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffects
{
    protected float effectDuration;
    protected float effectLifetime;
    protected bool expired;

    public StatusEffects(float duration)
    {
        effectDuration = duration;
        effectLifetime = 0f;
    }

    public abstract void UpdateStatusEffect();

    public bool IsExpired()
    {
        return expired;
    }

}
