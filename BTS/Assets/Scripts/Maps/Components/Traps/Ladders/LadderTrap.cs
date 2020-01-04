using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderTrap : TrapComponent
{
    protected override void OnActivate()
    {
        base.OnActivate();
        UpdateTiles();
    }

    private void UpdateTiles()
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

    protected override void TypeChanged()
    {
        base.TypeChanged();
        UpdateTiles();
    }
}
