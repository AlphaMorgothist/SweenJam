using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrap : TrapComponent
{
    protected override void ApplyEffect(AICharacter character)
    {
        if (trapType == TrapTypes.FIRE)
        {
            //character gets burned
        }
        else if (trapType == TrapTypes.ICE)
        {
            //character gets frozen for a short duration
        }
        else if (trapType == TrapTypes.SLOW)
        {
            //character gets slowed for a short duration
        }
    }
}
