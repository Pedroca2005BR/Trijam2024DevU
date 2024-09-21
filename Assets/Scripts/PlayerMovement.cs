using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D characterController;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool isJumping = false;


    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        
    }

    private void FixedUpdate()
    {
        //Move our character 
        characterController.Move(horizontalMove * Time.fixedDeltaTime, false, isJumping);
        isJumping = false;


    }
}
