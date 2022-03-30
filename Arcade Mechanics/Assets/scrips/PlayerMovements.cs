using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;
    private Vector3 moveDirection;
    public float gravityScale;
    public Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
        float yStore = moveDirection.y;
        moveDirection = (Input.GetAxis("Vertical") * Time.deltaTime * transform.forward) + (Input.GetAxis("Horizontal") * Time.deltaTime * transform.right);
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;

        if(moveDirection.z > 0||moveDirection.x > 0)
        {
            animator.SetFloat("Speed", 1);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
        if (controller.isGrounded)
        {
            animator.SetBool("InAir", false);
            animator.SetBool("Jump", false);
            moveDirection.y = -1f;
            if (Input.GetButtonDown("Jump"))
            {
                animator.SetBool("Jump", true);
                moveDirection.y = jumpForce;
            }
        }
        else
        {
            animator.SetBool("InAir", true);
        }
        moveDirection.y += Physics.gravity.y * gravityScale * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}