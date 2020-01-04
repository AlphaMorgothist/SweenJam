using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : TrapComponent
{
    protected override void ApplyEffect(AICharacter character)
    {
        character.DamageChar(1);
    }
}
