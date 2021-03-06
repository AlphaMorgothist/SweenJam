﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderTrap : TrapComponent
{
    public GameObject basicLadderSprite;
    public GameObject unstableLadderSprite;
    public GameObject brokenLadderSprite;
    public GameObject fireLadderSprite;
    public GameObject iceLadderSprite;
    public GameObject slowLadderSprite;

    private void Start()
    {
        basicLadderSprite = gameObject.transform.GetChild(0).GetChild(0).gameObject;
        unstableLadderSprite = gameObject.transform.GetChild(0).GetChild(1).gameObject;
        brokenLadderSprite = gameObject.transform.GetChild(0).GetChild(2).gameObject;
        fireLadderSprite = gameObject.transform.GetChild(0).GetChild(3).gameObject;
        iceLadderSprite = gameObject.transform.GetChild(0).GetChild(4).gameObject;
        slowLadderSprite = gameObject.transform.GetChild(0).GetChild(5).gameObject;
    }
    protected override void ApplyEffect(AICharacter character)
    {
        if (trapType == TrapTypes.FIRE)
        {
            character.DamageChar(1);
        }
        else if (trapType == TrapTypes.ICE)
        {
            character.CharStatus.ApplyStatusEffect(new FreezeStatus(statusDuration));
        }
        else if (trapType == TrapTypes.SLOW)
        {
            //character gets slowed for a short duration
            character.CharStatus.ApplyStatusEffect(new SlowStatus(statusDuration));
        }
    }
    protected override void OnActivate()
    {
        base.OnActivate();
        if (trapType == TrapTypes.UNSTABLE)
        {
            gameObject.SetActive(false);
        }
        UpdateTiles();
    }

    protected override void UpdateTiles()
    {
        base.UpdateTiles();
        switch (trapType)
        {
            // Ladders can be Basic, Unstable(breakable), Broken, On Fire, Icy, or Slow(Sticky) //
            case TrapTypes.BASIC:
                TileDeActivator();
                basicLadderSprite.SetActive(true);
                update = false;
                break;
            case TrapTypes.UNSTABLE:
                TileDeActivator();
                unstableLadderSprite.SetActive(true);
                update = false;
                break;
            case TrapTypes.BROKEN:
                TileDeActivator();
                brokenLadderSprite.SetActive(true);
                update = false;
                break;
            case TrapTypes.FIRE:
                TileDeActivator();
                basicLadderSprite.SetActive(true);
                fireLadderSprite.SetActive(true);
                update = false;
                break;
            case TrapTypes.ICE:
                TileDeActivator();
                iceLadderSprite.SetActive(true);
                update = false;
                break;
            case TrapTypes.SLOW:
                TileDeActivator();
                slowLadderSprite.SetActive(true);
                update = false;
                break;
            default:
                break;
        }
    }

    protected override void TileDeActivator()
    {
        base.TileDeActivator();
        basicLadderSprite.SetActive(false);
        unstableLadderSprite.SetActive(false);
        brokenLadderSprite.SetActive(false);
        fireLadderSprite.SetActive(false);
        iceLadderSprite.SetActive(false);
        slowLadderSprite.SetActive(false);
    }
}
