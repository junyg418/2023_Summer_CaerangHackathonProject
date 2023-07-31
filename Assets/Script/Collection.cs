using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collection : MonoBehaviour
{
    public Image[] image = new Image[4];

    //public Inventory inventory;
    
    void Start()
    {
        //inventory = FindObjectOfType<Inventory>();

        for (int i = 0; i < image.Length; i++)
        {
            image[i].color = new Color(0.2f, 0.2f, 0.2f, 1);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void color(int index)
    {
        image[index].color = new Color(1, 1, 1, 1);
    }

  
}
