using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Resource health;
    public Resource mana;

    public BoolVariable isPlayerTurn;

    public EnemyList enemies;
    public Resource targetIndex;
    
    public GameEvent endTurnEvent;

    private void Update()
    {
        
    }

    //Performs a skill against an enemy (will be expanded)
    public void ExecuteSkill(Skill skill)
    {
        Debug.Log(skill.name + ": " + skill.skillCost);
        enemies.items[targetIndex.currentValue].TakeDamage(skill.skillDamage);
        endTurnEvent.Raise();
    }
}
