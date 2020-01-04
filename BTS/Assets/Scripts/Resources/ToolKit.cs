using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolKit : Resource
{
    public override void ChangeTrap(TrapComponent target)
    {
        //makes disabled traps interactable
        target.SetTrapType(TrapTypes.UNSTABLE);
    }
}
