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
        objectsSlot = GameObject.FindGameObjectsWithTag("Inventory_slot"); // slot �迭
        
    }
    void Start()
    {
        foreach (GameObject obj in objectsSlot)
        {
            obj.SetActive(false);
        }

        // ����� �����Ͱ� ���� ��
        if(saveInventory.LoadData())
            save_data = saveInventory.inventory_data; // ��ųʸ� ����
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

        // ���ٱ� 50%
        if (1 <= randomInt && randomInt < 50)
            append_item_to_inventory(1);
        else if (50 <= randomInt && randomInt < 80)
            append_item_to_inventory(2);
        else if (50 <= randomInt && randomInt < 101)
            Debug.Log("3�� ����");
            //append_item_to_inventory(3);

        init_slot();
    }
    /// <summary>
    /// �κ��丮�� ������ �߰��ϴ� �۾�
    /// </summary>
    /// <param name="item_id">�������� id �� �Է¹���</param>
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
        var save_data_keys = new List<int>(save_data.Keys); // ��ųʸ��� key �� �迭

        int length = save_data.Count; // ��ųʸ��� ����
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

        Debug.Log("�����");
    } 

    public bool LoadData()
    {
        filePath = Path.Combine(Application.persistentDataPath, "data.json");
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);

            inventory_data = JsonUtility.FromJson<Dictionary<int, int>>(jsonData);

            Debug.Log("�ҷ���");
            return true;
        }
        else
        {
            Debug.Log("����� ������ ����");
            return false;
        }
    }
}