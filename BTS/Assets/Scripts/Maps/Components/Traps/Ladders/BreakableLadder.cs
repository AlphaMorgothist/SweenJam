using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableLadder : LadderTrap
{
    public static BreakableLadder Instance;

    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    protected override void OnActivate()
    {
        base.OnActivate();

    }
}
