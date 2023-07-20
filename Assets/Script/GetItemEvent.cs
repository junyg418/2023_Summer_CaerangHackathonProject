using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GetItemEvent : MonoBehaviour
{
    public GameObject default_find_img;
    //public SpriteRenderer spriterenderer;
    public KeyCode interactionKey = KeyCode.Space;
    
    public float time_to_get_item = 3.0f;
    private float keyPressStartTime;
    private bool isKeyHold = false; 

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
        if (!target.tag.Equals("GoPoint")) 
            return;

        default_find_img.SetActive(true);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;
        if (!target.tag.Equals("GoPoint")) 
            return;

        if (Input.GetKeyDown(interactionKey)){
            isKeyHold = true;
            keyPressStartTime = Time.time;
            StartCoroutine(ActiveObjcetForSecond(target));
        }
        else if (Input.GetKeyUp(interactionKey)){
            isKeyHold = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;
        if (!target.tag.Equals("GoPoint")) 
            return;

        default_find_img.SetActive(false);
    }

    IEnumerator ActiveObjcetForSecond(GameObject target)
    {
        while (isKeyHold)
        {
            float passed_time = Time.time - keyPressStartTime;
            if (passed_time >= 3.0f)
            {
                Debug.Log("아이템 얻음!");
                Destroy(target);
                yield break;
            }
            else if(passed_time >= 2.0f)
            {
                Debug.Log("2초 지남");
            }
            else if(passed_time >= 1.0f)
            {
                Debug.Log("1초 지남");
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
