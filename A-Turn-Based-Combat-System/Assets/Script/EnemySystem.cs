using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour {

    public BoolVariable isPlayerTurn;
    public GameEvent endTurnEvent;

    public EnemyList enemies;

	// Update is called once per frame
	void Update () {
        if (!isPlayerTurn.value)
            PerformAction();
	}

    void PerformAction()
    {
        for (int i = enemies.items.Count-1; i >= 0 ; i--)
        {
            enemies.items[i].ExecuteAction();
        }      

        endTurnEvent.Raise();
    }
}
