using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSkill : MonoBehaviour
{
    [SerializeField]
    public float move_speed = 1.5f;
    public float pauseTime = 30f;


    private List<Vector3> sc_arr;
    private Vector3 goal_pos;
    private bool updatePaused = false;
    private float passedTime = 0f;
    private bool first_flg = true;

    void Update()
    {
        if (RandomItemPoint.point_pos_array != null)
        {
            sc_arr = RandomItemPoint.point_pos_array;
            if(first_flg)
            {
                goal_pos = sc_arr[0];
                first_flg = false;
            }
        }

        if (updatePaused)
        {
            passedTime += Time.deltaTime;
            if (passedTime > pauseTime)
            {
                passedTime = 0f;
                updatePaused = false;

            }
            return;
        }


        if (sc_arr[0] != goal_pos)
        {
            goal_pos = sc_arr[0];
            updatePaused = true;
            Debug.Log("∏ÿ√„ Ω√¿€?");
        }
        Vector3 direction = goal_pos - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, goal_pos, move_speed * Time.deltaTime);
    }
}
