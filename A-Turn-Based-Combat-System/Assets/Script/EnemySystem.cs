using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour {

    public BoolVariable isPlayerTurn;
    public GameEvent endTurnEvent;

	// Update is called once per frame
	void Update () {
        if (!isPlayerTurn.value)
            PerformAction();
	}

    void PerformAction()
    {
        print("Enemy Performs an Action!");
        endTurnEvent.Raise();
    }
}
