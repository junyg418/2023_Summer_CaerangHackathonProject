using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEditor.Progress;

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
        objectsSlot = GameObject.FindGameObjectsWithTag("Inventory_slot"); // slot �迭mw
    }
    void Start()
    {
        // slot init
        foreach (GameObject obj in objectsSlot)
        {
            obj.SetActive(false);
        }

        // ����� �����Ͱ� ���� ��
        if(saveInventory.LoadData())
            save_data = saveInventory.inventory_data; // ��ųʸ� ����
        init_slot();

        // information init
        set_information();
    }

    // Update is called once per frame
    void Update()
    {  
            
    }
    
    public void get_item()
    {
        int randomInt = Random.Range(1, 101);

        // ���ٱ� 50%
        if (1 <= randomInt && randomInt < 50)
            append_item_to_inventoryData(1);
        // ���� 30%
        else if (50 <= randomInt && randomInt < 80)
            append_item_to_inventoryData(2);
        else if (50 <= randomInt && randomInt < 101)
            Debug.Log("3�� ����");
            //append_item_to_inventory(3);

        init_slot();
    }
    /// <summary>
    /// �κ��丮�� ������ �߰��ϴ� �۾�
    /// </summary>
    /// <param name="item_id">�������� id �� �Է¹���</param>
    private void append_item_to_inventoryData(int item_id)
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
    /// <summary>
    /// slot �ʱ�ȭ�ϴ� function
    /// </summary>
    private void init_slot()
    {
        var save_data_keys = new List<int>(save_data.Keys); // ��ųʸ��� key �� �迭

        int length = save_data.Count; // ��ųʸ��� ����
        for (int idx = 0; idx < length; idx++)
        {
            GameObject current_slot = objectsSlot[idx];
            int current_item_id = save_data_keys[idx];

            current_slot.SetActive(true);
            set_slot_count(current_slot, current_item_id);
            set_slot_img(current_slot, current_item_id);
            set_slot_button(current_slot, current_item_id);
        }
    }
    /// <summary>
    /// slot�� ������ ������ �ʱ�ȭ���ִ� function
    /// </summary>
    /// <param name="current_slot">���� slot</param>
    /// <param name="item_id">�������� id</param>
    private void set_slot_count(GameObject current_slot, int item_id)
    {
        TextMeshProUGUI child_text_component = current_slot.transform.GetComponentInChildren<TextMeshProUGUI>();
        child_text_component.text = string.Format("X {0}", save_data[item_id]);
    }
    private void set_slot_img(GameObject current_slot, int item_id)
    {
        foreach(ItemData item in _items)
        {
            if(item.ID == item_id)
            {
                current_slot.GetComponent<Image>().sprite = item.itemImage;
                break;
            }
        }
    }
    private void set_slot_button(GameObject current_slot, int item_id)
    {
        GameObject slot_button_gameObject = current_slot.transform.GetChild(1).gameObject;
        Button slot_button = slot_button_gameObject.GetComponent<Button>();
        foreach(ItemData item in _items)
        {
            if(item.ID == item_id)
            {
                UnityAction<ItemData> buttonClickEventAction = new UnityAction<ItemData>(set_information);
                slot_button.onClick.AddListener(() => buttonClickEventAction.Invoke(item));
            }
        }
    }

    // information ���� function
    private void set_information()
    {
        set_information_text("������");
        set_information_toolTip("����");
    }
    public void set_information(ItemData item)
    {
        set_information_text(item.itemName);
        set_information_toolTip(item.Tooltip);
    }
    /// information function
    private void set_information_text(string input_text="")
    {
        GameObject information_text_gameObject = information_object.transform.GetChild(0).gameObject;

        information_text_gameObject.GetComponent<Text>().text = input_text;
    }
    private void set_information_toolTip(string input_text="")
    {
        GameObject information_toolTip_gameObject = information_object.transform.GetChild(1).gameObject;

        information_toolTip_gameObject.GetComponent<Text>().text = input_text;
    }


    // money_text ����
    private void set_currentMoney_text(int money_count = 0)
    {

    }
}


public class SaveInventory
{
    public Dictionary<int, int> inventory_data = new Dictionary<int, int>();
    private string filePath;
    private class CustomDictionary
    {
        public List<int> keys;
        public List<int> values;
    }

    public void SaveData(Dictionary<int, int> save_dict)
    {
        CustomDictionary data = new CustomDictionary
        {
            keys = new List<int>(save_dict.Keys),
            values = new List<int>(save_dict.Values)
        };

        string jsonData = JsonUtility.ToJson(data);
        Debug.Log(jsonData);
        filePath = Path.Combine("./", "data.json");
        File.WriteAllText(filePath, jsonData);

        Debug.Log("저장 성공");
    } 

    public bool LoadData()
    {
        filePath = Path.Combine("./", "data.json");
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);

            CustomDictionary tmp_dic = JsonUtility.FromJson<CustomDictionary>(jsonData);

            for (int i = 0; i < tmp_dic.values.Count; i++)
                inventory_data[tmp_dic.keys[i]] = tmp_dic.values[i];

            Debug.Log("저장 성공");
            return true;
        }
        else
        {
            Debug.Log("저장 실패");
            return false;
        }
    }

    public int[] LoadID()
    {
        filePath = Path.Combine("./", "data.json");
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);

            CustomDictionary id_data = JsonUtility.FromJson<CustomDictionary>(jsonData);
            return id_data.keys.ToArray();
        }
        else
            return new int[0];
    }
}