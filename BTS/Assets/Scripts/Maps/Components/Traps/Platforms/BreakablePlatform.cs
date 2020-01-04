using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatform : PlatformTrap
{
    protected override void OnActivate()
    {
        base.OnActivate();
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
