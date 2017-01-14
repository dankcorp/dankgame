using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DankWeaponManager : MonoBehaviour {

    public int weaponType = 0;
    private GameObject weapon; 

	
	void Start () {
        weapon = transform.Find("CharacterHandler/Weapon").gameObject;
	}
	
	
	void Update () {
		if (weaponType != 0)
        {
            weapon.gameObject.transform.GetChild(weaponType).gameObject.SetActive(true);

        } else
        {
            weapon.gameObject.transform.GetChild(weaponType).gameObject.SetActive(false);

        }
	}
}
