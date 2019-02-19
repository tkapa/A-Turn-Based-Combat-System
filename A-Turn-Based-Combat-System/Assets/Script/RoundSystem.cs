using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSystem : MonoBehaviour {

    public BoolVariable isPlayerTurn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeRoundState()
    {
        print("The turn has been passed");
        isPlayerTurn.value = !isPlayerTurn.value;
    }
}
