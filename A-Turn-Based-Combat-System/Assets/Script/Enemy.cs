using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Data
{
    public string name;
    public float health;
    public List<Skill> skills;
    public bool isTargeted;
    public Mesh model;
}

[CreateAssetMenu(fileName ="New Enemy", menuName ="Enemy")]
public class Enemy : ScriptableObject {
        
    public Data data;       
}
