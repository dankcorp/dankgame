using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DankWeaponManager : MonoBehaviour {

    public int weaponType = 0;
    public bool isAiming = false; // est en train de viser

    public GameObject shootWeapon;
    public GameObject handWeapon;
    private GameObject weapon;
    public DankPlayerProperties player;
    private Animator weaponAnimator;

    public GameObject spawnPoint;    // point de départ de la balle
    private float nextfire;
    private float cool;
    private Rigidbody projectile;
    public Rigidbody projectilePrefab;
    public Rigidbody RPG;


    private int[,] chargeurAmmo;
    private int[,] totalAmmo;
    public Text displayAmmo;
    public Image ammoBackground;
    private string ammoChargeur, slash, ammoTot;
    private int wp;

    private float reloadTime;
    private float nextReload;

    public int ejectSpeed;

    public bool fps;

    void Start () {

        weapon = handWeapon;
        player = this.GetComponent<DankPlayerProperties>();
        weaponAnimator = shootWeapon.GetComponent<Animator>();
        projectile = projectilePrefab;
        
        // 1er tableau : [munitions actuelles du chargeur , capacité du chargeur]
        // 2em tableau : [munitions totales , munitions max pouvant etre transportées]
        totalAmmo = new int[,] { { 35, 90, 5 }, { 35, 90, 5 } };  
        chargeurAmmo = new int[,] { { 7, 30, 1 }, { 7, 30, 1 } };

        nextfire = Time.time;     // temps avant le prochain tir
        nextReload = Time.time;   // temps avant le prochain rechargement
        cool = 0.5f;              // cadence de tir
        reloadTime = 0.7f;        // temps de rechargement


        displayAmmo.transform.Translate(Screen.width / 2.5f, -Screen.height / 2.5f, 0);    // positionne le text des ammos

        Color c = ammoBackground.color;     // set le background des ammos => transparence et position
        c.a = 0.6f;                         
        ammoBackground.color = c;
        ammoBackground.transform.Translate(Screen.width / 2.5f, -Screen.height / 2.5f, 0);
        

    }

    


    void Update () {
        wp = weaponType - 1;
        aim();
        ChangeWeapon();

        if (isAiming) { // condition bizarre de matthieu ne pas toucher

            weaponAnimator.SetInteger("WeaponType_int", weaponType);
            weaponAnimator.SetBool("Shoot_b", player.shot);
        }


        if (Input.GetButton("Fire1") && Time.time >= nextfire && chargeurAmmo[0, wp] > 0)
            Shoot();
        

        if (Input.GetKey(KeyCode.R)  || chargeurAmmo[0, wp] == 0)
            Reload();

        UpdateAmmoText();
    }


    public void Shoot() // fonction de tir
    {
        Rigidbody bullet;
        bullet = Instantiate(projectile, spawnPoint.transform.position, spawnPoint.transform.rotation) as Rigidbody;
        bullet.velocity = transform.TransformDirection(Vector3.forward * ejectSpeed);
        nextfire = Time.time + cool;

        chargeurAmmo[0, wp]--; // enlève une balle du chargeur C'EST LOGIQUE ENCULÉ
    }


    public void Reload () // fonction de rechargement
    {

        // fix le temps de rechargement
        

        totalAmmo[0, wp] += chargeurAmmo[0, wp] - chargeurAmmo[1,wp];

        chargeurAmmo[0, wp] = chargeurAmmo[1, wp];
    }



    public void UpdateAmmoText()
    {
        displayAmmo.text = chargeurAmmo[0, wp].ToString() + "  /  " + totalAmmo[0, wp].ToString();
    }


    public void ChangeWeapon() // change l'arme actuelle
    {
        setChildrenOff(weapon);
      
       
        if (Input.GetKey(KeyCode.Alpha1))
        {
            weaponType = 1;
            cool = 0.5f;
            projectile = projectilePrefab;
            reloadTime = 0.7f;
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            weaponType = 2;
            cool = 0.1f;
            projectile = projectilePrefab;
            reloadTime = 1.2f;
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            weaponType = 3;
            projectile = RPG;
            cool = 2f;
            reloadTime = 2f;
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            weaponType = 4;
            projectile = projectilePrefab;
            cool = 1f;
            reloadTime = 1.5f;
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            weaponType = 5;
            cool = 0.1f;
            projectile = projectilePrefab;
            reloadTime = 1.2f;
        }
        else if (Input.GetKey(KeyCode.Alpha6))
        {
            weaponType = 6;
            cool = 2f;
            projectile = projectilePrefab;
            reloadTime = 3f;
        }
        else if (Input.GetKey(KeyCode.Alpha7))
        {
            weaponType = 7;
            cool = 2f;
            projectile = projectilePrefab;
            reloadTime = 3f;
        }
        else if (Input.GetKey(KeyCode.Alpha8))
        {
            weaponType = 8;
            cool = 0.1f;
            projectile = projectilePrefab;
            reloadTime = 1.2f;
        }
        else if (Input.GetKey(KeyCode.Alpha9))
        {
            weaponType = 9;
            cool = 0.1f;
            projectile = projectilePrefab;
            reloadTime = 1.2f;
        }
        else if (Input.GetKey(KeyCode.Alpha0))
        {
            weaponType = 10;
            cool = 0.1f;
            projectile = projectilePrefab;
            reloadTime = 1.2f;
        }

     

        weapon.gameObject.transform.GetChild(weaponType).gameObject.SetActive(true);

    }


    public int getWeaponType()
    {
        return weaponType;
    }

    public void aim()   // fonction bizarre de matthieu ne pas toucher
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

    private void setChildrenOff(GameObject gameObject)     // fonction bizarre de matthieu ne pas toucher
    {
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(false);
        }

    }
}
