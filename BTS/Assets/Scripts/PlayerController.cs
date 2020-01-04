using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    private Resource activeResource;
    public List<Potion> redPotions;
    public List<Potion> greenPotions;
    public List<Potion> bluePotions;
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
