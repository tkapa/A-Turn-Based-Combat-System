﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSystem : MonoBehaviour {

    public BoolVariable isPlayerTurn;

    public void ChangeRoundState()
    {
        isPlayerTurn.value = !isPlayerTurn.value;
    }
}
