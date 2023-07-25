using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    public ItemData[] _items;
    public GameObject information_object;

    private SaveInventory saveInventory = new SaveInventory();
    private Dictionary<int, int> save_data = new Dictionary<int, int>();
    private GameObject[] objectsSlot;


    private void Awake()
    {
        objectsSlot = GameObject.FindGameObjectsWithTag("Inventory_slot"); // slot 배열
        
    }
    void Start()
    {
        foreach (GameObject obj in objectsSlot)
        {
            obj.SetActive(false);
        }

        // 저장된 데이터가 있을 때
        if(saveInventory.LoadData())
            save_data = saveInventory.inventory_data; // 딕셔너리 형태
        save_data.Add(1, 3);
        save_data.Add(2, 6);
        init_slot();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    public void get_item()
    {
        int randomInt = Random.Range(1, 101);

        // 뼈다귀 50%
        if (1 <= randomInt && randomInt < 50)
            append_item_to_inventory(1);
        else if (50 <= randomInt && randomInt < 80)
            append_item_to_inventory(2);
        else if (50 <= randomInt && randomInt < 101)
            Debug.Log("3번 떴음");
            //append_item_to_inventory(3);

        init_slot();
    }
    /// <summary>
    /// 인벤토리에 아이템 추가하는 작업
    /// </summary>
    /// <param name="item_id">아이템의 id 를 입력받음</param>
    private void append_item_to_inventory(int item_id)
    {
        if (save_data.ContainsKey(item_id))
        {
            if (save_data[item_id] >= 99)
                return;
            else
                save_data[item_id] += 1;
        }
        else
            save_data[item_id] = 1;
    }

    private void init_slot()
    {
        var save_data_keys = new List<int>(save_data.Keys); // 딕셔너리의 key 의 배열

        int length = save_data.Count; // 딕셔너리의 길이
        for (int idx = 0; idx < length; idx++)
        {
            GameObject current_slot = objectsSlot[idx];
            current_slot.SetActive(true);
            set_slot_count(current_slot, save_data_keys[idx]);
        }
    }

    private void set_slot_count(GameObject current_slot, int item_id)
    {
        TextMeshProUGUI child_text_component = current_slot.transform.GetComponentInChildren<TextMeshProUGUI>();
        child_text_component.text = string.Format("X {0}", save_data[item_id]);
    }
}


public class SaveInventory
{
    public Dictionary<int, int> inventory_data = new Dictionary<int, int>();
    private string filePath;

    public void SaveData(Dictionary<int, int> save_dict)
    {
        string jsonData = JsonUtility.ToJson(save_dict);

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