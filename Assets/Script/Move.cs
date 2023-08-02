using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[RequireComponent(typeof(Rigidbody2D))]
public class Move : MonoBehaviour
{
    float Speed = 7;

    public Animator animator;

    private Rigidbody2D _rigidbody2D;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0;
        float moveY = 0;

        if (Input.GetKey(KeyCode.A))
        {
            moveX -= Speed;
            animator.SetBool("isleft", true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("isleft", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveX += Speed;
            animator.SetBool("isright", true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("isright", false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            moveY += Speed;
            animator.SetBool("isback", true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("isback", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveY -= Speed;
            animator.SetBool("isfront", true);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("isfront", false);
        }

        Vector2 moveVector = new Vector2(moveX, moveY);
        _rigidbody2D.AddForce(moveVector);

    }
}

