using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : TrapComponent
{
    Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (body.velocity != Vector2.zero)
            isActive = true;
        else
            isActive = false;
    }

    protected override void ApplyEffect(AICharacter character)
    {
        character.DamageChar(1);
    }
}
