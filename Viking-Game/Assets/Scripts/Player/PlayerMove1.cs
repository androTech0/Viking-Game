using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove1 : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jump = 3f;
    public float gravity = -9.10f;
    public CharacterController controller;
    public Animator animator;
    public Transform ground_check;
    public float ground_distance = 0.4f;
    public LayerMask ground_mask;
    Vector3 MoveDirection = Vector3.zero;
    Vector3 volecity;
    bool isGround;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics.CheckSphere(ground_check.position,ground_distance,ground_mask);

        if (isGround && volecity.y < 0 ) {
            volecity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move*moveSpeed*Time.deltaTime);

        if (x > 0)
        {
            animator.SetBool("right", true);
        }
        else if (x < 0)
        {
            animator.SetBool("left", true);
        }
        else {
            animator.SetBool("right", false);
            animator.SetBool("left", false);
        }
        if (z > 0)
        {
            animator.SetBool("forword", true);
        }
        else if (z < 0)
        {
            animator.SetBool("backword", true);
        }
        else
        {
            animator.SetBool("forword", false);
            animator.SetBool("backword", false);
        }
        if (isGround && Input.GetButton("Jump")) {
            volecity.y = Mathf.Sqrt(jump * -2f * gravity);
            animator.SetBool("jump", true);
        }
        else
        {
            animator.SetBool("jump", false);
        }

        volecity.y += gravity * Time.deltaTime;

        controller.Move(volecity * Time.deltaTime);
    }
}
