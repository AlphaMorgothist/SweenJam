using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrateTrap : TrapComponent
{
    protected override void ApplyEffect(AICharacter character)
    {
        if (trapType == TrapTypes.FIRE)
        {
            character.DamageChar(1);
        }
        else if (trapType == TrapTypes.ICE)
        {
            character.CharStatus.ApplyStatusEffect(new FreezeStatus(statusDuration));
        }
        else if (trapType == TrapTypes.SLOW)
        {
            character.CharStatus.ApplyStatusEffect(new SlowStatus(statusDuration));
        }
        else if (trapType == TrapTypes.SPIKE)
        {
            character.DamageChar(1);
        }
    }
}
