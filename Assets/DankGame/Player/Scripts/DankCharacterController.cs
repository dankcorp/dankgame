using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DankCharacterController : MonoBehaviour
{



    public  float mouseSensibility = 1;
    private float lookSmooth = 0.09f;
    private float smoothX = 0;
    private float smoothXvelocity = 0;
    private float lookAngle;
    private CharacterController charController;
    private Vector3 moveDirection = Vector3.zero;

    private DankPlayerProperties player;


    void Start()
    {
    
        charController = this.GetComponent<CharacterController>();
       
        player = this.GetComponent<DankPlayerProperties>();

        moveVertical = moveHorizontal = 0;
    }




    void Update()
    {
      
       RotationMouseMovement();
       move();
        
    }

    float moveVertical, moveHorizontal;

    private void move()
    {
        moveVertical = Input.GetAxis("Vertical"); //forwardinput
        moveHorizontal = Input.GetAxis("Horizontal"); //turniput


  
            
        moveDirection = new Vector3(moveHorizontal, 0, moveVertical);

        
        moveDirection = transform.TransformDirection(moveDirection);
        


        player.shot = Input.GetKey(KeyCode.Mouse0);
        player.aim = Input.GetKey(KeyCode.Mouse1) || player.shot;

        player.walk = (moveVertical != 0 || moveHorizontal != 0) && !player.aim;
        player.run = (player.walk && Input.GetKey(KeyCode.LeftShift));
        player.grounded = charController.isGrounded;

        
             

        float speed = player.walkSpeed;

        if (player.aim)
        {
            speed = player.walkSpeedSlow;
        }
        else if (player.run)
        {
            speed = player.runSpeed;
        }

        moveDirection *= speed;
        moveDirection += Vector3.down * player.gravity;

        charController.Move(moveDirection * Time.deltaTime);

        if (player.shot)
        {
            shoot();
        }

 
    }


    void RotationMouseMovement()
    {

        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        if (lookSmooth > 0)
        {
            smoothX = Mathf.SmoothDamp(smoothX, x, ref smoothXvelocity, lookSmooth);
        }
        else
        {
            smoothX = x;
        }

        lookAngle += smoothX * player.turnSpeed * mouseSensibility;

        transform.rotation = Quaternion.Euler(0, lookAngle, 0);
    }

    void shoot()
    {
        Debug.Log("shoot");
    }



}

