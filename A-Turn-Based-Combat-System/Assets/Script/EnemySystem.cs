using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour {

    public BoolVariable isPlayerTurn;
    public GameEvent endTurnEvent;

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
            PlayerWins();
            return;
        }
            

        for (int i = enemies.items.Count-1; i >= 0 ; i--)
        {
            enemies.items[i].ExecuteAction();
        }      

        endTurnEvent.Raise();
    }

    //Does something if the player has won
    void PlayerWins()
    {
        print("The player has won");
        isPlayerTurn.value = true;
    }
}
