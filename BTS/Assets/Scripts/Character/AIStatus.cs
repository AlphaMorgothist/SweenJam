using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStatus
{
    public enum StatusType { Normal, Feared, Frozen, Slowed, Slicked }
    [SerializeField] StatusType currentStatus;
    private List<StatusEffects> statusEffects;

    // Constructor 
    public AIStatus()
    {
        currentStatus = StatusType.Normal;
    }

    public void UpdateStatus()
    {
        foreach (StatusEffects status in statusEffects)
        {
            status.UpdateStatusEffect();
            if (status.IsExpired())
                statusEffects.Remove(status);
        }
    }

    public void ApplyStatusEffect(StatusEffects status)
    {
        statusEffects.Add(status);
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
