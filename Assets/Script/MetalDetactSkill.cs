using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalDetactSkill : MonoBehaviour
{
    [SerializeField]
    //public float zero_dis = 40f; // 이 변수보다 크면 _0
    public float first_dis = 20f; // 이 변수보다 크면 _1
    public float sec_dis = 10f;
    public float max_dis = 5f;

    public Sprite default_wifi;
    public Sprite first_wifi;
    public Sprite sec_wifi;
    public Sprite max_wifi;

    private SpriteRenderer sprite_obj;
    private Vector3 goal_vector;
    private float min_dis;

    void Start()
    {
        min_dis = float.MaxValue;
        sprite_obj = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        min_dis = float.MaxValue;
        foreach(Vector3 data in RandomItemPoint.point_pos_array)
        {
            float tmp_dis = (data - transform.position).sqrMagnitude;
            if(tmp_dis < min_dis)
            {
                min_dis = tmp_dis;
                goal_vector = data;
            }
        }
        set_wifi_img(goal_vector);
    }

    private void set_wifi_img(Vector3 goal_pos)
    {
        float distance = Vector3.Distance(transform.position, goal_pos);
        if (distance < max_dis)
        {
            sprite_obj.sprite = max_wifi;
        }
        else if(distance < sec_dis)
        {
            sprite_obj.sprite = sec_wifi;
        }
        else if (distance < first_dis)
        {
            sprite_obj.sprite = first_wifi;
        }
        else
        {
            sprite_obj.sprite = default_wifi;
        }

    }
}