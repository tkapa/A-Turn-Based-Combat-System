using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Resource health;
    public Resource mana;

    public BoolVariable isPlayerTurn;

    public GameEvent endTurnEvent;

    public void ExecuteSkill(Skill skill)
    {
        Debug.Log(skill.name + ": " + skill.skillCost);
        endTurnEvent.Raise();
    }
}
