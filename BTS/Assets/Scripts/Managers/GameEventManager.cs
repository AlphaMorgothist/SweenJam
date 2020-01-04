using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager 
{
    public delegate void GameEvent();

    public static GameEvent GameStart;
    public static GameEvent GameOver;
    public static GameEvent Restart;
    public static GameEvent GameWin;

    public static void TriggerGameStart()
    {
        if (GameStart != null)
            GameStart();
    }

    public static void TriggerGameOver()
    {
        if (GameOver != null)
            GameOver();
    }

    public static void TriggerRestart()
    {
        if (Restart != null)
            Restart();
    }

    public static void TriggerGameWin()
    {
        if (GameWin != null)
            GameWin();
    }
}
