using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStats
{
    //Class functionality members
    float moveSpeed, jumpHeight, health, recoverySpeed;
    public enum StatType { move, jump, hp, recover};
    
    
    public AIStats(float moveS, float jumpH, float HP, float recoSpeed) 
    {
        moveSpeed = moveS;
        jumpHeight = jumpH;
        health = HP;
        recoverySpeed = recoSpeed;
    }

    /// <summary>
    /// Called to change a stat on the character
    /// </summary>
    /// <param name="type"> AIStats.StatType Enum</param>
    /// <param name="amount">Amount to affect stat by</param>
    /// <param name="damaging">Is this a damage effect?</param>
    public void AffectStat(StatType type, float amount, bool damaging)
    {
        //Ternery operator to switch between adding to stat or damaging it
        float dam = damaging ? amount : -amount;
        switch (type)
        {
            case StatType.move:
                moveSpeed = Mathf.Clamp(moveSpeed + dam, 1, 100);
                break;
            case StatType.jump:
                jumpHeight = Mathf.Clamp(jumpHeight + dam, 1, 100);
                break;
            case StatType.hp:
                health = Mathf.Clamp(health + dam, 0, 100);
                break;
            case StatType.recover:
                recoverySpeed = Mathf.Clamp(recoverySpeed + dam, 1, 100);
                break;
            default:
                break;
        }
    }
}
