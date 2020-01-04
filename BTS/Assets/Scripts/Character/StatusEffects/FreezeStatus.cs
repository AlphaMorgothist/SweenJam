using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeStatus : StatusEffects
{
    public FreezeStatus(float duration) :
        base(duration)
    { }

    public override void UpdateStatusEffect()
    {
        effectLifetime += Time.deltaTime;
        if (effectLifetime >= effectDuration)
        {
            expired = true;
        }
        else
        {
            //apply change to modifier
            //and pause the character controller
        }
    }
}
