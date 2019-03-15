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
    public GameEvent playerWinsEvent;

    private void Start()
    {
        enemies.items[targetIndex.currentValue].Targeted();
        health.currentValue = health.maximumValue;
        mana.currentValue = mana.maximumValue;
    }

    private void Update()
    {
        if (health.currentValue <= 0)
        {
            playerWinsEvent.Raise();
        }            
    }

    //Performs a skill against an enemy (will be expanded)
    public void ExecuteSkill(Skill skill)
    {
        Debug.Log(skill.name + ": " + skill.cost);

        if (skill.cost <= mana.currentValue && isPlayerTurn)
        {
            mana.currentValue -= skill.cost;
            enemies.items[targetIndex.currentValue].TakeDamage(skill.damage);
        }
        else
            print("Cannot cast this, turn is passed");

        endTurnEvent.Raise();
    }
}
