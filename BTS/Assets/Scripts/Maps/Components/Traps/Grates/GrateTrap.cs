using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrateTrap : TrapComponent
{
    protected override void ApplyEffect(AICharacter character)
    {
        if (trapType == TrapTypes.FIRE)
        {
            //burn the character
        }
        else if (trapType == TrapTypes.ICE)
        {
            //freezes character for a short duration
        }
        else if (trapType == TrapTypes.SLOW)
        {
            //player gets slowed for a short duration
        }
        else if (trapType == TrapTypes.SPIKE)
        {
            //player takes damage
        }
    }
}
