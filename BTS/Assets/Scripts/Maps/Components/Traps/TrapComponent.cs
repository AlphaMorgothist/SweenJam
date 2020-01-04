﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapComponent : MapComponent
{
    public TrapTypes trapType;
    protected bool isActive;

    private void Update()
    {
        if(isActive)
        {
            OnActivate();
        }
    }

    protected virtual void UpdateTiles()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isActive)
        {
            if (collision.collider.CompareTag("AI"))
            {
                ApplyEffect();
            }
        }
    }

    public void ApplyEffect()
    {
        switch (trapType)
        {
            // This function will handle all trap effects on the AI //
            case TrapTypes.BASIC:
                break;
            case TrapTypes.UNSTABLE:
                break;
            case TrapTypes.BROKEN:
                break;
            case TrapTypes.FIRE:
                break;
            case TrapTypes.ICE:
                break;
            case TrapTypes.SLOW:
                break;
            case TrapTypes.SPIKE:
                break;
            case TrapTypes.SLIPPERY:
                break;
            default:
                break;
        }
    }

    virtual protected void OnActivate()
    {

    }

    public void SetTrapType(TrapTypes type)
    {
        if (trapType == type) 
            return; //Traps cannot be changed into itself
        if (trapType == TrapTypes.BROKEN)
            return; //Broken traps cannot be changed into anything else
        if ((trapType != TrapTypes.UNSTABLE) &&
            type == TrapTypes.BROKEN)
            return; //Only unstable traps can be broken
        if ((trapType == TrapTypes.SPIKE)
            && type != TrapTypes.BASIC)
            return; //Spike traps can only become basic
        trapType = type;
        TypeChanged();
    }

    protected virtual void TypeChanged()
    {

    }
}
