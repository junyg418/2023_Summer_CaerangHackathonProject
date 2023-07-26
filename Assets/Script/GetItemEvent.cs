using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class GetItemEvent : MonoBehaviour
{
    public GameObject default_find_img;
    //public SpriteRenderer spriterenderer;
    public KeyCode interactionKey = KeyCode.Space;

    public Slider slider;
    public Canvas canvas;

    private Rigidbody2D rb;

    public RandomItemPoint randomItemPoint;

    // Start is called before the first frame update
    void Start()
    {
        //randomItemPoint = GameObject.Find("Spawn").GetComponent<RandomItemPoint>();
        default_find_img.SetActive(false);
        canvas.enabled = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKey(KeyCode.Space))
        {
            rb.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
            slider.value = 0;
            canvas.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;
        if (!target.tag.Equals("GoPoint"))
            return;

        default_find_img.SetActive(true);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;
        if (!target.tag.Equals("GoPoint"))
            return;

        if (Input.GetKey(interactionKey))
        {
            StartCoroutine(ActiveObjcetForSecond(target));
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;
        if (!target.tag.Equals("GoPoint"))
            return;
        slider.value = 0;

        default_find_img.SetActive(false);
        canvas.enabled = false;
    }

    IEnumerator ActiveObjcetForSecond(GameObject target)
    {
        while (Input.GetKey(KeyCode.Space))
        {
            canvas.enabled = true;
            rb.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;

            slider.value += 0.001f;

            if (slider.value == 1)
            {
                
                Debug.Log("아이템 얻음!");
                Destroy(target);
                randomItemPoint.Spawn();
                canvas.enabled = false;
                yield break;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}


