using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSkill : MonoBehaviour
{
    List<Vector3> sc_arr;
    Vector3 goal_pos;
    void Start()
    {
        
    }

    void Update()
    {
        if(RandomItemPoint.point_pos_array != null)
        {
            sc_arr = RandomItemPoint.point_pos_array;
        }

    }
}
