using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    public ItemData item;

    Text valueText;

    // Start is called before the first frame update
    void Start()
    {
        valueText = GetComponent<Text>();
        
    }

    // Update is called once per frame
    public void valueUpdate(float value)
    {
        valueText.text = Mathf.RoundToInt(value)+"°³";
    }

}
