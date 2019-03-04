using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour {

    public Enemy enemyData;
    public EnemyList enemies;

    [SerializeField]
    private Data data;

    public GameEvent deathEvent;
    public Material material;
    public bool isTargeted;

    public Resource playerTarget;

    private void Start()
    {
        data = enemyData.data;
        GetComponent<MeshFilter>().mesh = data.model;
        Targeted();
    }

    //Ensure the enemy adds and removes themselves from the enemy list automatically
    private void OnEnable()
    {
        enemies.Add(this);
    }

    private void OnDisable()
    {
        enemies.Remove(this);
    }

    //Sets player's current target to clicked enemy
    private void OnMouseDown()
    {
        enemies.items[playerTarget.currentValue].Targeted();
        playerTarget.currentValue = enemies.items.FindIndex(s=>s==this);
        Targeted();
    }

    //Determines skill to use on own turn
    public void ExecuteAction()
    {
        Debug.Log("Enemy performed an Action!");
    }

    //Changes status of enemy to targeted or untargeted
    public void Targeted()
    {
        if (isTargeted)
        {
            material.SetFloat("_IsTargeted", 1);
        }
        else
        {
            material.SetFloat("_IsTargeted", 0);
        }

        isTargeted = !isTargeted;
    }

    //Called things that happen when the enemy takes damage
    public void TakeDamage(int damage)
    {
        data.health -= damage;

        if (data.health <= 0)
            Death();
    }

    void Death()
    {
        //Exp rewards, death actions, run enemy death events
        if (isTargeted)
        {
            if (playerTarget.currentValue > 0)
                playerTarget.currentValue--;

            enemies.items[playerTarget.currentValue].Targeted();
        }

        deathEvent.Raise();
        this.gameObject.SetActive(false);
    }
}
