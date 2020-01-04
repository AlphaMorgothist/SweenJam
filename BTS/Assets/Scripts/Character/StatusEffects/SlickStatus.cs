using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlickStatus : StatusEffects
{
    public SlickStatus(float duration) :
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
        }
    }
}
