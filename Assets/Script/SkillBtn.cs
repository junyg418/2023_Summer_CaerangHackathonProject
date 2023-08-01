using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBtn : MonoBehaviour
{
    public GameObject gameobject;
    // Start is called before the first frame update
    void Start()
    {
        gameobject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        if (gameobject.activeSelf == false)
        {
            gameobject.SetActive(true);
        }

        else if (gameobject.activeSelf == true)
        {
            gameobject.SetActive(false);
        }

    }
}
