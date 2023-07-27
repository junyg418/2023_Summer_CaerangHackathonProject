using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collection : MonoBehaviour
{
    //public GameObject slot;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = image.GetComponent<Image>() ;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
            image.color = new Color(1, 1, 1);
    }
}
