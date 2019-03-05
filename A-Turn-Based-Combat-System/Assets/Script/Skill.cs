using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skill")]
public class Skill : ScriptableObject {

    public enum DamageType{
        none,
        physical,
        magical
    }

    public new string name;
    public int cost;
    public int damage;
    public DamageType type;
}
