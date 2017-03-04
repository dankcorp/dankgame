using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DankWeaponManager : MonoBehaviour {

    public int weaponType = 0;
    public bool isAiming = false; // est en train de viser

    public GameObject shootWeapon;
    public GameObject handWeapon;
    private GameObject weapon;
    public DankPlayerProperties player;
    private Animator weaponAnimator;

    public GameObject spawnPoint;
    private float nextfire = Time.time;
    private float cool = 0.5f;
    private Rigidbody projectile;
    public Rigidbody projectilePrefab;
    public Rigidbody RPG;

    public int ejectSpeed;


    public bool fps;

    void Start () {
        weapon = handWeapon;
        player = this.GetComponent<DankPlayerProperties>();
        weaponAnimator = shootWeapon.GetComponent<Animator>();
        projectile = projectilePrefab;
    }

    


    void Update () {

        aim();
        ChangeWeapon();

        if (isAiming) {

            weaponAnimator.SetInteger("WeaponType_int", weaponType);
            weaponAnimator.SetBool("Shoot_b", player.shot);
        }

        if (Input.GetButton("Fire1") && Time.time >= nextfire)
        {
            Shoot();
        }


    }


    public void Shoot()
    {
        Rigidbody bullet;
        bullet = Instantiate(projectile, spawnPoint.transform.position, spawnPoint.transform.rotation) as Rigidbody;
        bullet.velocity = transform.TransformDirection(Vector3.forward * ejectSpeed);
        nextfire = Time.time + cool;
    }


    public void ChangeWeapon()
    {
        setChildrenOff(weapon);
      
       
        if (Input.GetKey(KeyCode.Alpha1))
        {
            weaponType = 1;
            cool = 0.5f;
            projectile = projectilePrefab;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            weaponType = 2;
            cool = 0.1f;
            projectile = projectilePrefab;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            weaponType = 3;
            projectile = RPG;
            cool = 2f;
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


    public int getWeaponType()
    {
        return weaponType;
    }

    public void aim()
    {


        isAiming = player.aim || fps;

        if (isAiming)
        {
            weapon = shootWeapon;
            handWeapon.SetActive(false);
        }
        else
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
}
