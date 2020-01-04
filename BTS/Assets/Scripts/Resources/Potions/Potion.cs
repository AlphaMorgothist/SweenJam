using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Resource
{
    public TrapTypes potionType;

    public override void ChangeTrap(TrapComponent target)
    {
        target.SetTrapType(potionType);
    }

    public void SetPotionType(TrapTypes type)
    {
        potionType = type;
    }
}
