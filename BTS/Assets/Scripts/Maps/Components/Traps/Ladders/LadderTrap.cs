using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderTrap : TrapComponent
{

    private void Update()
    {
        switch(trapType)
        {
            case TrapTypes.BASIC:
                break;
            case TrapTypes.UNSTABLE:
                break;
            case TrapTypes.BROKEN:
                break;
            case TrapTypes.FIRE:
                
            default:
                break;
        }
    }


}
