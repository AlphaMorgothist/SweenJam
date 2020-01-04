using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderTrap : TrapComponent
{
    protected override void ApplyEffect(AICharacter character)
    {
        if (trapType == TrapTypes.FIRE)
        {
            //character gets burned
        }
        else if (trapType == TrapTypes.ICE)
        {
            //character freezes for a short duration
        }
        else if (trapType == TrapTypes.SLOW)
        {
            //character gets slowed for a short duration
        }
    }
    protected override void OnActivate()
    {
        base.OnActivate();
        UpdateTiles();
    }

    protected override void UpdateTiles()
    {
        switch (trapType)
        {
            // Ladders can be Basic, Unstable(breakable), Broken, On Fire, Icy, or Slow(Sticky) //
            case TrapTypes.BASIC:
                break;
            case TrapTypes.UNSTABLE:
                break;
            case TrapTypes.BROKEN:
                break;
            case TrapTypes.FIRE:
                break;
            case TrapTypes.ICE:
                break;
            case TrapTypes.SLOW:
                break;
            default:
                break;
        }
    }
}
