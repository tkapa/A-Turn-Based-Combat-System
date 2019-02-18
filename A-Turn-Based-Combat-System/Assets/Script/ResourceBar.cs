using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBar : MonoBehaviour {

    public Resource resourceData;

    public Slider slider;
    public Text text;

    private void Start()
    {
        slider.maxValue = resourceData.maximumValue;
        slider.value = resourceData.currentValue;

        text.text = resourceData.name;
    }

    // Update is called once per frame
    void Update () {
        slider.value = resourceData.currentValue;
	}
}
