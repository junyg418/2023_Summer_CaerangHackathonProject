using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour
{
    Text valueText;
    public static int sell_count = 0;

    // Start is called before the first frame update
    void Start()
    {
        valueText = GetComponent<Text>();
        
    }

    // Update is called once per frame
    public void valueUpdate(float value)
    {
        valueText.text = Mathf.RoundToInt(value)+"°³";
        sell_count = Mathf.RoundToInt(value);
    }

}
