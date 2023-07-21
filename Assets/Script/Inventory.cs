using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    //public ItemData[] _items;
    private SaveInventory saveInventory = new SaveInventory();
    private Dictionary<string, int> save_data;

    void Start()
    {
        GameObject[] objectsSlot = GameObject.FindGameObjectsWithTag("Inventory_slot"); // slot �迭
        foreach (GameObject obj in objectsSlot)
        {
            obj.SetActive(false);
        }

        // ����� �����Ͱ� ���� ��
//        if (saveInventory.LoadData())
//        {
            save_data = saveInventory.inventory_data; // ��ųʸ� ����
            save_data.Add("bone", 3);
            var save_data_keys = new List<string>(save_data.Keys); // ��ųʸ��� key �� �迭

            int length = save_data.Count; // ��ųʸ��� ����
            for (int idx=0; idx < length; idx++)
            {
                objectsSlot[idx].SetActive(true);
                Text child_text_component = transform.GetComponentInChildren<Text>();
                child_text_component.text = string.Format("X {0}", save_data[save_data_keys[idx]]);
            }
  //      }


    }

    // Update is called once per frame
    void Update()
    {
        
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

public class SaveInventory : MonoBehaviour
{
    public Dictionary<string, int> inventory_data = new Dictionary<string, int>();
    private string filePath;

    public void SaveData()
    {
        string jsonData = JsonUtility.ToJson(inventory_data);

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

            inventory_data = JsonUtility.FromJson<Dictionary<string, int>>(jsonData);

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