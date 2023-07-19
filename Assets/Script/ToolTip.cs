using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ToolTip : MonoBehaviour, IPointerClickHandler
{
    public List<Item> items;

    [SerializeField]
    private Inventory _titleText;   // 아이템 이름 텍스트

    [SerializeField]
    private Inventory _contentText; // 아이템 설명 텍스트

    public void SetItemInfo(Item data)
    {
        _titleText.text = data.itemName;
        _contentText.text = data.Tooltip;
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        Debug.Log(_titleText);
        Debug.Log( _contentText);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
