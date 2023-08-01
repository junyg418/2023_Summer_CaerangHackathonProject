using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalDetactSkill : MonoBehaviour
{
    [SerializeField]
    //public float zero_dis = 40f; // �� �������� ũ�� _0
    public float first_dis = 20f; // �� �������� ũ�� _1
    public float sec_dis = 10f;
    public float max_dis = 5f;

    public Sprite default_wifi;
    public Sprite first_wifi;
    public Sprite sec_wifi;
    public Sprite max_wifi;

    public GameObject gameObject;

    private Sprite sprite_obj;

    void Start()
    {
        sprite_obj = GetComponent<SpriteRenderer>().sprite;
    }

    void Update()
    {
        
    }

    private void set_wifi_img(Vector3 goal_pos)
    {
        float distance = Vector3.Distance(transform.position, goal_pos);
        if (distance < max_dis)
        {
            sprite_obj = max_wifi;
        }
        else if(distance < sec_dis)
        {
            sprite_obj = sec_wifi;
        }
        else if (distance < first_dis)
        {
            sprite_obj = first_wifi;
        }
        else
        {
            sprite_obj = default_wifi;
        }

    }
}