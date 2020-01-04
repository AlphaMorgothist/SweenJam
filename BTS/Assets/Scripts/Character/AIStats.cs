using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStats
{
    float moveSpeed, jumpHeight, health, recoverySpeed;

    public AIStats(float moveS, float jumpH, float HP, float recoSpeed) 
    {
        moveSpeed = moveS;
        jumpHeight = jumpH;
        health = HP;
        recoverySpeed = recoSpeed;
    }
}
