using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour {

    public Skill skillData;
    public Text skillText;

    private Player player;    

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();

        skillText.text = skillData.skillName;
    }

    public void PassSkill()
    {
        player.ExecuteSkill(skillData);
    }
}
