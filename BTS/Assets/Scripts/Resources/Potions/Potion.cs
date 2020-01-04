using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Resource
{
    public TrapTypes potionType;

    protected override void ChangeTrap(TrapComponent target)
    {
        target.SetTrapType(potionType);
    }
}
