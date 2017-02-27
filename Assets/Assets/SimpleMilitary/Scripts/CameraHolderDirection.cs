using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolderDirection : MonoBehaviour {

    public Transform target;
    public float lookSmooth = 0.09f;
   

    DankCharacterController charController;
    float rotateVel = 0;

    // Use this for initialization
    void Start()
    {
        SetCameraTarget(target);
    }

    void SetCameraTarget(Transform t)
    {
        target = t;

        if (target != null)
        {
            if (target.GetComponent<DankCharacterController>())
            {
                charController = target.GetComponent<DankCharacterController>();
            }
            else
            {
                Debug.LogError("The camera's target needs a character controller.");
            }
        }
        else
        {
            Debug.LogError("Your camera needs a target");
        }

    }

    // Update is called once per frame
    void Update () {
        LookAtTarget();
    }

    void LookAtTarget()
    {

        float eulerYAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref rotateVel, lookSmooth);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, eulerYAngle, 0);



    }
}
