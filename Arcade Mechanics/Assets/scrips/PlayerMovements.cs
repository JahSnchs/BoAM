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

        moveDirection.y += Physics.gravity.y * gravityScale * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        if (moveDirection.z != 0 || moveDirection.x != 0)
        {
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("walk", false);
        }
        if (controller.isGrounded)
        {
            animator.SetBool("fall", false);
        }
        else
        {
            animator.SetBool("fall", true);
        }

    }
}