﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour {

    public BoolVariable isPlayerTurn;

    public GameEvent endTurnEvent;
    public GameEvent playerWinsEvent;

    public EnemyList enemies;

    //Checks if it is the enemy turn
    public void CheckTurn()
    {
        if (!isPlayerTurn.value)
            PerformAction();
    }

    //Checks if enemies are dead, calls execute action if not, returns turn
    void PerformAction()
    {
        if (enemies.items.Count == 0)
        {
            playerWinsEvent.Raise();
            return;
        }
            

        for (int i = enemies.items.Count-1; i >= 0 ; i--)
        {
            enemies.items[i].ExecuteAction();
        }      

        endTurnEvent.Raise();
    }
}
