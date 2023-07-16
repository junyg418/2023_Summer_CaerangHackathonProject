using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    public GameObject default_find_img;
    //public SpriteRenderer spriterenderer;
    public KeyCode interactionKey = KeyCode.Space;

    // Start is called before the first frame update
    void Start()
    {
        default_find_img.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;
        if (!target.tag.Equals("GoPoint")) return;
        default_find_img.SetActive(true);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;
        if (!target.tag.Equals("GoPoint")) return;
        if (Input.GetKeyDown(interactionKey))
        {
            Debug.Log("æ∆¿Ã≈€");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;
        if (!target.tag.Equals("GoPoint")) return;
        default_find_img.SetActive(false);
    }
}
