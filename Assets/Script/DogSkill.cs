using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSkill : MonoBehaviour
{
    List<Vector3> sc_arr;
    Vector3 goal_pos;
    public float move_speed = 3.0f;

    void Start()
    {
    }

    void Update()
    {
        if (RandomItemPoint.point_pos_array != null)
            sc_arr = RandomItemPoint.point_pos_array;
            goal_pos = sc_arr[0];

        if (sc_arr[0] != goal_pos)
        {
            goal_pos = sc_arr[0];
        }

        Vector3 direction = goal_pos - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, goal_pos, move_speed*Time.deltaTime);
    }
}
