using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DankCameraController : MonoBehaviour {

    public Transform target;
    public float lookSmooth = 0.09f;
    public Vector3 TPSCameraPosition = new Vector3(0, 0, 0);
    public Vector3 TPSZoomCameraPosition = new Vector3(0, 2, 1);

    public Vector3 FPSCameraPosition = new Vector3(0, 2, 1);
    public bool mode = true; // true for TPS, false for FPS 
    Vector3 targetPosition;
    private float tiltAngle;
   
   

    private float smoothX = 0;
    private float smoothY = 0;
    private float smoothXvelocity = 0;
    private float smoothYvelocity = 0;
    private float lookAngle;
    private float turnSpeed = 1.5f;
    public float tiltMax = 75f;
    public float tiltMin = 45f;

    public GameObject player;
    DankPlayerProperties playerproperties;

    // Use this for initialization
    void Start ()
    {
        playerproperties = player.GetComponent<DankPlayerProperties>();

    }

   
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
            mode = !mode;

        if (mode)
        {
            if (Input.GetMouseButton(1))
            {
                targetPosition = target.TransformPoint(TPSZoomCameraPosition);
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            }
            else
            {
                targetPosition = target.TransformPoint(TPSCameraPosition);
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
            }

        } else
        {

            targetPosition = target.TransformPoint(FPSCameraPosition);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }

        

      

    }

    void LateUpdate()
    {

        HandleRotationMovement();
    }

    void setPosition()
    {


    }

    void HandleRotationMovement()
    {
      

        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        if (lookSmooth > 0)
        {
            smoothX = Mathf.SmoothDamp(smoothX, x, ref smoothXvelocity, lookSmooth);
            smoothY = Mathf.SmoothDamp(smoothY, y, ref smoothYvelocity, lookSmooth);
        }
        else
        {
            smoothX = x;
            smoothY = y;
        }

        lookAngle += smoothX * turnSpeed;


        tiltAngle -= smoothY * turnSpeed;
        tiltAngle = Mathf.Clamp(tiltAngle, -tiltMin, tiltMax);

        transform.rotation = Quaternion.Euler(tiltAngle, player.transform.eulerAngles.y, 0);
       


    }
}
