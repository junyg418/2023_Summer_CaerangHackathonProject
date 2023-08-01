using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PopUp : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Color targetColor = new Color(1, 1, 1, 1);

    public GameObject popup;

    private RectTransform rectTransform;
    private Vector2 panelOffset;

    // Start is called before the first frame update
    void Start()
    {
        popup.SetActive(false);

        rectTransform = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameObject.CompareTag("Slot"))
        {
            if (IsColorEqual(GetComponent<Graphic>().color, targetColor))
            {
                Vector3 panelPosition = rectTransform.position;
                panelPosition.y -= rectTransform.rect.height / 2f + popup.GetComponent<RectTransform>().rect.height / 2f + 10f;
                popup.transform.position = panelPosition;


                popup.SetActive(true);
            }
        }

        if (gameObject.CompareTag("skill_slot"))
        {
            if (IsColorEqual(GetComponent<Graphic>().color, targetColor))
            {
                Vector3 panelPosition = rectTransform.position;
                panelPosition.y -= rectTransform.rect.height / 2f + popup.GetComponent<RectTransform>().rect.height / 2f + 10f;
                popup.transform.position = panelPosition;


                popup.SetActive(true);
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (gameObject.CompareTag("Slot"))
        {
            popup.SetActive(false);
        }

        if (gameObject.CompareTag("skill_slot"))
        {
            popup.SetActive(false);
        }
    }

    private bool IsColorEqual(Color color1, Color color2)
    {
        return color1.r == color2.r && color1.g == color2.g && color1.b == color2.b && color1.a == color2.a;
    }
}
