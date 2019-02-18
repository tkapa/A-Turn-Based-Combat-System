using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour {

    public Skill skillData;

    public Text skillText;

	// Use this for initialization
	void Start () {
        skillText.text = skillData.skillName;
	}
}
