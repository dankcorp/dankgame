using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DankAnimatorController : MonoBehaviour {

    public float speed;
    public int weaponType = 0;

    Animator animator;
    CharacterController cController;
    private GameObject characterHandler;
    

    // Use this for initialization
    void Start () {

        characterHandler = transform.Find("CharacterHandler").gameObject;
        animator = characterHandler.GetComponent<Animator>();
        cController = characterHandler.GetComponent<CharacterController>();

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(1))
        {

            weaponType = 2;
        }
        else
        {
            weaponType = 0;
        }


        speed = cController.velocity.magnitude;
        animator.SetFloat("Speed_f", speed);
        animator.SetInteger("WeaponType_int", weaponType);
    }
}
