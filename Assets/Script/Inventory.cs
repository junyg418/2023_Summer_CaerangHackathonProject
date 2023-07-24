using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    //public ItemData[] _items;
    private SaveInventory saveInventory = new SaveInventory();
    private Dictionary<int, int> save_data = new Dictionary<int, int>();

    void Start()
    {
        GameObject[] objectsSlot = GameObject.FindGameObjectsWithTag("Inventory_slot"); // slot 배열
        foreach (GameObject obj in objectsSlot)
        {
            obj.SetActive(false);
        }

        // 저장된 데이터가 있을 때
            save_data = saveInventory.inventory_data; // 딕셔너리 형태
            save_data.Add(1, 3);
            var save_data_keys = new List<int>(save_data.Keys); // 딕셔너리의 key 의 배열

            int length = save_data.Count; // 딕셔너리의 길이
        for (int idx = 0; idx < length; idx++)
        {
            GameObject current_slot = objectsSlot[idx];
            current_slot.SetActive(true);
            set_slot_count(current_slot, save_data_keys[idx]);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void set_slot_count(GameObject current_slot, int item_id)
    {
        TextMeshProUGUI child_text_component = current_slot.transform.GetComponentInChildren<TextMeshProUGUI>();
        child_text_component.text = string.Format("X {0}", save_data[item_id]);
    }
}

//public class SlotData : MonoBehaviour
//{
//    public ItemData item_data;
//    private int item_count;
//
//    public GameObject parentObject;
//    public GameObject uiTextPrefab;
//
//    public SlotData(ItemData item_data, int count)
//    {
//        this.item_data = item_data;
//        this.item_count = count;
//    }
//    private void Start()
//    {
//        GameObject uiTextObject = Instantiate(uiTextPrefab, parentObject.transform);
//
//        UnityEngine.UI.Text uiTextComponent = uiTextObject.GetComponent<UnityEngine.UI.Text>();
//        uiTextComponent.text = string.Format("+ {0}", item_count);
//    }
//}

public class SaveInventory
{
    public Dictionary<int, int> inventory_data = new Dictionary<int, int>();
    private string filePath;

    public void SaveData()
    {
        string jsonData = JsonUtility.ToJson(inventory_data);

        filePath = Path.Combine(Application.persistentDataPath, "data.json");
        File.WriteAllText(filePath, jsonData);

        Debug.Log("저장됨");
    } 

    public bool LoadData()
    {
        filePath = Path.Combine(Application.persistentDataPath, "data.json");
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);

            inventory_data = JsonUtility.FromJson<Dictionary<int, int>>(jsonData);

            Debug.Log("불러옴");
            return true;
        }
        else
        {
            Debug.Log("저장된 파일이 없음");
            return false;
        }
    }
}