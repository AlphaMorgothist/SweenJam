using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    private Resource activeResource;
    public List<RedPotion> redPotions;
    public List<GreenPotion> greenPotions;
    public List<BluePotion> bluePotions;
    public List<ToolKit> toolKits;

    public void SetActiveResource(Resource resource)
    {
        activeResource = resource;
    }

    public void ChangeTargetTrap(TrapComponent trap)
    {
        if (activeResource != null)
        {
            activeResource.ChangeTrap(trap);
        }
        else
        {
            trap.SetTrapType(TrapTypes.BROKEN);
        }
    }
}
