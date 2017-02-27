using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DankCharacterController : MonoBehaviour
{

    public float inputDelay = 0.1f; //le personnage met 0.1sc avant d'avancer c'est smooth

    

    private float lookSmooth = 0.09f;
    private float smoothX = 0;
    private float smoothXvelocity = 0;
    private float lookAngle;
    private CharacterController charController;
    private Vector3 moveDirection = Vector3.zero;
    private Rigidbody rb;

    private DankPlayerProperties player;
    private DankAnimatorController animator;
    public Vector3 jumpPosition = new Vector3(0, 3, 0);

    void Start()
    {
    
        charController = this.GetComponent<CharacterController>();
        rb = this.GetComponent<Rigidbody>();
        player = this.GetComponent<DankPlayerProperties>();
        animator = this.GetComponent<DankAnimatorController>();

        moveVertical = moveHorizontal = 0;
    }




    void FixedUpdate()
    {
      
        RotationMouseMovement();
        aim();
          
       move();
        
    }

    float moveVertical, moveHorizontal;
    private Vector3 velocity = Vector3.zero;
    public Vector3 posSaut = new Vector3(0,0,0);
    public float smoothTime = 0.9F;

    private void move()
    {
        moveVertical = Input.GetAxis("Vertical"); //forwardinput
        moveHorizontal = Input.GetAxis("Horizontal"); //turniput
        if(moveVertical > 0)
        {
            player.walk = true;
        }

        moveDirection = new Vector3(moveHorizontal, 0, moveVertical);
        moveDirection = transform.TransformDirection(moveDirection);

        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            moveDirection *= 0;
        }

        if (player.aim)
        {
            moveDirection *= player.walkSpeedSlow;
          

        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            moveDirection *= player.runSpeed;
        }
        else
        {
            moveDirection *= player.walkSpeed;
        }

        moveDirection += Vector3.down * player.gravity;



        player.shot = Input.GetKey(KeyCode.Mouse0);
        Debug.Log("ici");
        Debug.Log(player.shot);
        if(player.shot)
        {
            shoot();
        }

        charController.Move(moveDirection * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
         
            // jump
          

        }
    }

    void aim()
    {
        player.aim = Input.GetKey(KeyCode.Mouse1);
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

        lookAngle += smoothX * player.turnSpeed;

        transform.rotation = Quaternion.Euler(0, lookAngle, 0);
    }

    void shoot()
    {
        Debug.Log("shoot");

    }



}

