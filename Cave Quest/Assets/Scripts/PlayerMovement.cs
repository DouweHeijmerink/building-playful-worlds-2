using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    private Rigidbody2D m_Rigidbody2D;
    float horizontalMove = 0f;
    bool jump = false;

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Checks for a 1 or -1 value to determine which way the player is moving
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsFalling", false);
        }

        if (m_Rigidbody2D.velocity.y < -2)
        {
            animator.SetBool("IsFalling", true);
            animator.SetBool("IsJumping", false);
        }
    }

    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsFalling", false);
    }

    void FixedUpdate()
    {
        //Used to move the character, and checks whether the player is jumping or crouching
        //Time.FixedDeltaTime makes sure that our player moves normal speed no matter how often the function is called
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
