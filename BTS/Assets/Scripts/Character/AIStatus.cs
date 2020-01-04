using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStatus
{
    public enum StatusType { Normal, Feared, Confused }
    [SerializeField] StatusType currentStatus;

    // Constructor 
    public AIStatus()
    {
        currentStatus = StatusType.Normal;
    }

    /// <summary>
    /// Changes the character status to specified type
    /// </summary>
    /// <param name="type">Desired status effect. Use CharacterStatus.StatusType </param>
    public void EffectStatus(StatusType type)
    {
        currentStatus = type;
    }

    /// <summary>
    /// Called to get the current active status of the character
    /// </summary>
    /// <returns> Current Status of Character </returns>
    public StatusType GetStatus()
    {
        return currentStatus;
    }
}
