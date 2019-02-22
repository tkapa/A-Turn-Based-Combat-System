using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Resource health;
    public Resource mana;

    public BoolVariable isPlayerTurn;

    public EnemyList enemies;
    private int targetIndex = 0;


    public GameEvent endTurnEvent;

    private void Update()
    {
        
    }

    public void ExecuteSkill(Skill skill)
    {
        Debug.Log(skill.name + ": " + skill.skillCost);
        enemies.items[targetIndex].TakeDamage(skill.skillDamage);
        endTurnEvent.Raise();
    }
}
