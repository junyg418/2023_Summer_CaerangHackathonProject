using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBtn : MonoBehaviour
{
    public int count;
    public GameObject gameobject;

    public Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        gameobject.SetActive(false);
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        if (count == 0)
        {
            if (inventory._current_money >= 500)
            {
                inventory._current_money -= 500;
                inventory.set_currentMoney_text();
                count++;
            }
        }

        else
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
}
