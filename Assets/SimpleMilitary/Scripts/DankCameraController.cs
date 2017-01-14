using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DankCameraController : MonoBehaviour {

    public Transform target;
    public float lookSmooth = 0.09f;
    public Vector3 TPSCameraPosition = new Vector3(0, 0, 0);
    public Vector3 FPSCameraPosition = new Vector3(0, 2, 1);
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

    // Use this for initialization
    void Start ()
    {
       
	}

   
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        

        if (Input.GetMouseButton(1))
        {
            targetPosition = target.TransformPoint(FPSCameraPosition);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        } else
        {
            targetPosition = target.TransformPoint(TPSCameraPosition);
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

        transform.rotation = Quaternion.Euler(0f, lookAngle, 0);

        tiltAngle -= smoothY * turnSpeed;
        tiltAngle = Mathf.Clamp(tiltAngle, -tiltMin, tiltMax);

        transform.rotation = Quaternion.Euler(tiltAngle, lookAngle, 0);
    
    }
}
