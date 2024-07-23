using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 10;
    public float jumpHeight = 10;
    public float gravity = 9.81f;
    public float airControl = 10;
    public float rotationSpeed = 10;
    Animator animator;
    CharacterController controller;
    Vector3 input;
    Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        input = (Vector3.right * moveHorizontal + Vector3.forward * moveVertical).normalized;
        input *= moveSpeed;

        if(controller.isGrounded)
        {
            moveDirection = input;

            if(Input.GetButton("Jump"))
            {
                moveDirection.y = Mathf.Sqrt(2 * jumpHeight * gravity);
            }
            else
            {
                moveDirection.y = 0.0f;
            }
        }
        else
        {
            input.y = moveDirection.y;
            moveDirection = Vector3.Lerp(moveDirection, input, airControl * Time.deltaTime);
        }



        moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);

        Vector3 turnDirection = new Vector3(moveDirection.x, 0, moveDirection.z);
        if(turnDirection != Vector3.zero){
            animator.SetBool("isRunning", true);
            Quaternion targetRotation = Quaternion.LookRotation(turnDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
}
