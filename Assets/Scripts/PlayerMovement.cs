using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerMovement : MonoBehaviour
{
    bool reverseUnityEvent = false;


    public CharacterController2D characterController;
    public Animator animator;
    //public Buffs Buffs;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    public bool isJumping = false;
   


    // Teleport needs
    private bool isDisabled = false;
    public float teleportCooldown;
    private float teleportTimer = 0;


    // Update is called once per frame
    void Update()
    { 
        // Teleport needs
        if (isDisabled) return;
        teleportTimer -= Time.deltaTime;


        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;


        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        animator.SetFloat("Speed", horizontalMove);
        animator.SetBool("isJumping", isJumping);


    }

    private void FixedUpdate()
    {
        if (isDisabled) return; // Teleport needs

        //Move our character 
        characterController.Move(horizontalMove * Time.fixedDeltaTime, false, isJumping);


    }

    public void HitGround()
    {
        if (reverseUnityEvent)
        {
            isJumping = true;
        }
        else isJumping = false;
    }

    public void ChangeJumpForce(float force)
    {
        characterController.ChangeJumpForce(force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Teleporters") && teleportTimer <= 0)
        {
            StartCoroutine("Teleport", collision.gameObject.GetComponent<Teleporter>().opositeSide.position);
        }
    }


    public IEnumerator Teleport(Vector3 teleporter)
    {
        Vector3 newPosition;
        teleportTimer = teleportCooldown;

        isDisabled = true;
        yield return new WaitForSeconds(0.1f);

        newPosition =  new Vector3(transform.position.x, teleporter.y, transform.position.z);
        transform.position = newPosition;


        yield return new WaitForSeconds(0.1f);
        isDisabled = false;
    }

    public void SetMoveSpeedFast(float newSpeed)
    {
        runSpeed *= newSpeed;

    }
    public void SetMoveSpeedSlow(float newSpeed) 
    {
        runSpeed = runSpeed/newSpeed;

    }

    public void SetSpeedOpposite()
    {
        runSpeed *= -1;
    }

    public void SetLandEvent()
    {
        reverseUnityEvent = !reverseUnityEvent;
    }
    
}
