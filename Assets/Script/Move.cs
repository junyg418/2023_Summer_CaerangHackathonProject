using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Move : MonoBehaviour
{
    Vector2 position;
    public float Speed = 1;

    public Animator animator;

    private Rigidbody2D rigidbody2D;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        position = transform.position;
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
        rigidbody2D.AddForce(moveVector);

        Vector3 worldpos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worldpos.x < 0f) worldpos.x = 0f;
        if (worldpos.y < 0f) worldpos.y = 0f;
        if (worldpos.x > 1f) worldpos.x = 1f;
        if (worldpos.y > 1f) worldpos.y = 1f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worldpos);

    }
}

