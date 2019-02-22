using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Enemy", menuName ="Enemy")]
public class Enemy : ScriptableObject {

    public new string name;
    public float health;
    public List<Skill> skills =
        new List<Skill>();

    public bool isTargeted = false;

    public Mesh model;

    public EnemyList enemies;

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
        health -= damage;

        if (health <= 0)
            Death();
    }

    public void ExecuteAction()
    {
        Debug.Log("Enemy performed an Action!");
    }

    void Death()
    {
        //Exp rewards, death actions, run enemy death events
        Debug.Log("This one's dead, Chief");
    }
}
