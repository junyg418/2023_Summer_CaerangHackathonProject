using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    void Start()
    {
        menu.SetActive(false);
    }

    public GameObject menu;
    public void Openmenu()
    {
        if (menu.activeSelf == false)
        {
            menu.SetActive(true);
        }

        else if (menu.activeSelf == true)
        {
            menu.SetActive(false);
        }
    }
}
