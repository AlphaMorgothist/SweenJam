using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrap : TrapComponent
{
    // Platform traps include movable, breakable, and status affectable platforms
    public GameObject basicPlatformSprite;
    public GameObject unstablePlatformSprite;
    public GameObject firePlatformSprite;
    public GameObject icePlatformSprite;
    public GameObject slowPlatformSprite;


    private void Start()
    {
        basicPlatformSprite = gameObject.transform.GetChild(0).GetChild(0).gameObject;
        unstablePlatformSprite = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject;
        firePlatformSprite = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(1).gameObject;
        icePlatformSprite = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(2).gameObject;
        slowPlatformSprite = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(3).gameObject;
    }
    protected override void OnActivate()
    {
        base.OnActivate();
        if (trapType == TrapTypes.UNSTABLE)
        {
            gameObject.SetActive(false);
        }
    }


    protected override void ApplyEffect(AICharacter character)
    {
        if (trapType == TrapTypes.FIRE)
        {
            //character gets burned
        }
        else if (trapType == TrapTypes.ICE)
        {
            //character gets frozen for a short duration
        }
        else if (trapType == TrapTypes.SLOW)
        {
            //character gets slowed for a short duration
        }
    }

    protected override void UpdateTiles()
    {
        base.UpdateTiles();
        switch (trapType)
        {
            // Platforms can be Basic, Unstable(breakable), Broken, On Fire, Icy, or Slow(Sticky) //
            case TrapTypes.BASIC:
                TileDeActivator();
                basicPlatformSprite.SetActive(true);
                update = false;
                break;
            case TrapTypes.UNSTABLE:
                TileDeActivator();
                unstablePlatformSprite.SetActive(true);
                update = false;
                break;
            case TrapTypes.FIRE:
                TileDeActivator();
                firePlatformSprite.SetActive(true);
                update = false;
                break;
            case TrapTypes.ICE:
                TileDeActivator();
                icePlatformSprite.SetActive(true);
                update = false;
                break;
            case TrapTypes.SLOW:
                TileDeActivator();
                slowPlatformSprite.SetActive(true);
                update = false;
                break;
            default:
                break;
        }
    }
    protected override void TileDeActivator()
    {
        base.TileDeActivator();
        unstablePlatformSprite.SetActive(false);
        firePlatformSprite.SetActive(false);
        icePlatformSprite.SetActive(false);
        slowPlatformSprite.SetActive(false);
    }
}
