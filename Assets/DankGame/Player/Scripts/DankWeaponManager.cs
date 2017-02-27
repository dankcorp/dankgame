using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DankWeaponManager : MonoBehaviour {

    public int weaponType = 0;
    public bool isAiming = false; // est en train de viser

    public GameObject shootWeapon;
    public GameObject handWeapon;
    private GameObject weapon;
    public bool fps;

    void Start () {
        weapon = handWeapon;
    }

    public int getWeaponType()
    {
        return weaponType;
    }
 
    public void aim()
    {
        
        
        isAiming = Input.GetMouseButton(1) || fps;
        if(isAiming)
        {
            weapon = shootWeapon;
            handWeapon.SetActive(false);
        } else
        {
            weapon = handWeapon;
            shootWeapon.SetActive(false);
        }

        weapon.SetActive(true);
        
    }

    private void setChildrenOff(GameObject gameObject)
    {
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(false);
        }

    }


    void Update () {

        aim();
        changeWeapon();
	}

    public void changeWeapon()
    {
        setChildrenOff(weapon);
      
       
        if (Input.GetKey(KeyCode.Alpha1))
        {
            weaponType = 1;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            weaponType = 2;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            weaponType = 3;
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            weaponType = 4;
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            weaponType = 5;
        }
        else if (Input.GetKey(KeyCode.Alpha6))
        {
            weaponType = 6;
        }
        else if (Input.GetKey(KeyCode.Alpha7))
        {
            weaponType = 7;
        }
        else if (Input.GetKey(KeyCode.Alpha8))
        {
            weaponType = 8;
        }
        else if (Input.GetKey(KeyCode.Alpha9))
        {
            weaponType = 9;
        }
        else if (Input.GetKey(KeyCode.Alpha0))
        {
            weaponType = 10;
        }

     

        weapon.gameObject.transform.GetChild(weaponType).gameObject.SetActive(true);

    }
}
