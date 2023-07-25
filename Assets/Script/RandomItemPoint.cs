using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemPoint : MonoBehaviour
{

    public GameObject prefabs;
    //private GameObject area;
    private BoxCollider2D area;
    public int count = 5;

    // Start is called before the first frame update
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

    // Update is called once per frame
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
        Vector3 spawnPos = GetRandomPosition();//랜덤위치함수

        GameObject instance = Instantiate(prefabs, spawnPos, Quaternion.identity);
    }


}
