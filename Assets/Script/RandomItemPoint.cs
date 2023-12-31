using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemPoint : MonoBehaviour
{

    public GameObject prefabs;
    //private GameObject area;
    private BoxCollider2D area;
    public int count = 5;
    public static List<Vector3> point_pos_array = new List<Vector3>();

    void Start()
    {
        area = GetComponent<BoxCollider2D>();
        //area = GameObject.Find("Spawn");
        for (int i = 0; i < count; ++i)
        {
            Spawn();
        }

        //area.enabled = false;
    }

    void Update()
    {
        
    }
    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = transform.position;
        Vector3 size = area.size;

        float posX = basePosition.x + Random.Range(-size.x, size.x);
        float posY = basePosition.y + Random.Range(-size.y, size.y);

        Vector3 spawnPos = new Vector3(posX/2, posY/2);

        return spawnPos;
    }

    public void Spawn()
    {
        Vector3 spawnPos = GetRandomPosition();//������ġ�Լ�

        GameObject instance = Instantiate(prefabs, spawnPos, Quaternion.identity);
        set_point_pos_array(spawnPos);
    }

    private List<Vector3> set_point_pos_array(Vector3 pos_data)
    {
        point_pos_array.Add(pos_data);
        return point_pos_array;
    }

}
