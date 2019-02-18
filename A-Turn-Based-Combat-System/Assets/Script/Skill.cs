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

    public string skillName;
    public int skillCost;
    public int skillDamage;
    public DamageType damageType;
}
