using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Condensing the data required for easy copying.
[System.Serializable]
public struct Data
{
    public string name;
    public float health;
    public float maxHealth;
    public List<Skill> skills;
    public Texture texture;
}

[CreateAssetMenu(fileName ="New Enemy", menuName ="Enemy")]
public class Enemy : ScriptableObject {
        
    public Data data;       
}
