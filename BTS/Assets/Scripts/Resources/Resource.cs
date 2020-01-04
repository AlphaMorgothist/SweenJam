using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Resource : MonoBehaviour
{

    private bool active;

    protected abstract void ChangeTrap(TrapComponent target);
}
