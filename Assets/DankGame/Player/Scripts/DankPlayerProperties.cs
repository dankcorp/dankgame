using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DankPlayerProperties : MonoBehaviour {

    public float walkSpeed;
    public float walkSpeedSlow;
    public float runSpeed;
    public float turnSpeed; //doit etre la meme valeur que la caméra
    public float jumpSpeed;
    public float gravity;

    public bool walk;
    public bool run; 
    public bool grounded;
    public bool jump;
    public bool shot;
    public bool aim;
    public bool reload;
    public bool gamingMode; // 0 for fps 1 for TPS
    public GameObject MainCamera;
    public GameObject character;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //l'ordre d'appel est important
        updateGrounded();
        updateJump();
        updateShot();
        updateReload();
        updateMode();
        updateAim();

    }


    private void updateAim()
    {
        
        this.GetComponent<DankWeaponManager>().fps = (!gamingMode);
    }

    private void updateMode()
    {
        gamingMode = MainCamera.GetComponent<DankCameraController>().mode;
        character.SetActive(gamingMode);
        
    }

    private void updateGrounded()
    {
        RaycastHit hitInfo;
        grounded = (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, 0.1f)); //0.1f = groundcheckdistance
    }

    private void updateJump()
    {
        if (grounded && !jump)
            jump = Input.GetKeyDown(KeyCode.Space);
    }

    private void updateShot()
    {
        if (grounded)
            shot = Input.GetMouseButton(0);
    }

    private void updateReload()
    {
        //todo
    }




}

