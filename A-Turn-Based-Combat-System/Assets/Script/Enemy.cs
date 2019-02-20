using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Enemy", menuName ="Enemy")]
public class Enemy : ScriptableObject {

    public new string name;
    public float health;
    public List<Skill> skills =
        new List<Skill>();

    public Mesh model;

    private void OnEnable()
    {
 
    }

    private void OnDisable()
    {

    }

    public void ExecuteAction()
    {

    }
}
