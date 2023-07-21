using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    public ItemData[] _items;
    private ItemData Interface_tmp;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objectsSlot = GameObject.FindGameObjectsWithTag("Inventory_slot");
        foreach (GameObject obj in objectsSlot)
        {
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class SaveInventory : MonoBehaviour
{
    public Dictionary<string, int> inventory_data = new Dictionary<string, int>();
    private string filePath;

    public void SaveData()
    {
        string jsonData = JsonUtility.ToJson(inventory_data);

        filePath = Path.Combine(Application.persistentDataPath, "data.json");
        File.WriteAllText(filePath, jsonData);

        Debug.Log("저장됨");
    } 

    public void LoadData()
    {
        filePath = Path.Combine(Application.persistentDataPath, "data.json");
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);

            inventory_data = JsonUtility.FromJson<Dictionary<string, int>>(jsonData);

            Debug.Log("불러옴");
        }
        else
        {
            Debug.Log("저장된 파일이 없음");
        }
    }
}