using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour {

    public Enemy enemyData;
    public EnemyList enemies;

    [SerializeField]
    private Data data;

    public GameEvent deathEvent;

    private void Start()
    {
        data = enemyData.data;
        GetComponent<MeshFilter>().mesh = data.model;
    }

    private void OnEnable()
    {
        enemies.Add(this);
    }

    private void OnDisable()
    {
        enemies.Remove(this);
    }

    public void TakeDamage(int damage)
    {
        data.health -= damage;

        if (data.health <= 0)
            Death();
    }

    public void ExecuteAction()
    {
        Debug.Log("Enemy performed an Action!");
    }

    void Death()
    {
        //Exp rewards, death actions, run enemy death events
        deathEvent.Raise();
        this.gameObject.SetActive(false);
    }
}
