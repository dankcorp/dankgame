using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DankAnimatorController : MonoBehaviour {

    public float speed;
    public int  weaponType = 0;
    public CharacterController charController;
    Animator animator;
    public GameObject characterHandler;
    public GameObject character;
    DankWeaponManager weaponManager;
    DankPlayerProperties player;

    

    // Use this for initialization
    void Start () {

        animator = character.GetComponent<Animator>();
        weaponManager = this.GetComponent<DankWeaponManager>();
        player = this.GetComponent<DankPlayerProperties>();

    }

	
	// Update is called once per frame



	void Update () {

        speed = charController.velocity.magnitude;
        player.speed = speed;

        if (player.aim)
        {
            weaponType = weaponManager.getWeaponType();
            animator.SetBool("Shoot_b", player.shot);
            animator.SetFloat("Speed_f", 0);
        }
        else
        {
            weaponType = 0;
            animator.SetFloat("Speed_f", speed);
        }
        Debug.Log("ok");
        Debug.Log(weaponType);

        
       animator.SetInteger("WeaponType_int", weaponType);
    }
}
