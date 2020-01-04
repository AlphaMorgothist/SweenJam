using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : TrapComponent
{
    protected override void ApplyEffect(AICharacter character)
    {
        character.CharStatus.ApplyStatusEffect(new SlickStatus(statusDuration));
    }
}
