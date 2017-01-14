using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DankCharacterController : MonoBehaviour
{

    public float inputDelay = 0.1f; //le personnage met 0.1sc avant d'avancer c'est smooth
    public float walkSpeed = 12; //vitesse de marche
    public float turnSpeed = 1.5f;



  
    float moveVertical, moveHorizontal;

    private float lookSmooth = 0.09f;
    private float smoothX = 0;
    private float smoothXvelocity = 0;
    private float lookAngle;
    private CharacterController charController;
    private Vector3 moveDirection = Vector3.zero;
    private GameObject characterHandler;




    void Start()
    {
        characterHandler = transform.Find("CharacterHandler").gameObject;
        charController = characterHandler.GetComponent<CharacterController>();

        moveVertical = moveHorizontal = 0;
    }

    void GetInput()
    {
        moveVertical = Input.GetAxis("Vertical"); //forwardinput
        moveHorizontal = Input.GetAxis("Horizontal"); //turniput
    }

   

    void Update()
    {
        GetInput();
        HandleRotationMovement();
        Run();
    }

    private void Run()
    {

        moveDirection = new Vector3(moveHorizontal, 0, moveVertical);
        moveDirection = characterHandler.gameObject.transform.TransformDirection(moveDirection);
        moveDirection *= walkSpeed;
        charController.Move(moveDirection * Time.deltaTime);

    }


    void HandleRotationMovement()
    {

        float x = Input.GetAxis("Mouse X");

        if (lookSmooth > 0)
        {
            smoothX = Mathf.SmoothDamp(smoothX, x, ref smoothXvelocity, lookSmooth);
        }
        else
        {
            smoothX = x;
        }

        lookAngle += smoothX * turnSpeed;
        characterHandler.gameObject.transform.rotation = Quaternion.Euler(0f, lookAngle, 0);

        
    }

}

