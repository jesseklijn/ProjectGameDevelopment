using UnityEngine;
using System.Collections;
using System;

public class TowerControler : MonoBehaviour
{

    //Tower stats
    public float range;
    public float damage;
    public int fireRate;
    int fireDelay;

    //Gamemanager
    public GameManager gameManager;

    //Filler bool for selected tower
    public bool selected;

    //Bullet stuff
    public GameObject bullet;
    GameObject bulletSpawn;
    public float bulletSpeed;

    //misc. GameObjects
    GameObject[] enemys;
    GameObject target;
    GameObject rangeIndicator;


    //Fire a bullet at the selected target
    void Fire(Vector3 target)
    {
        //Create a bullet
        GameObject bulletClone = (GameObject)Instantiate(bullet, bulletSpawn.transform.position, transform.rotation);
        Rigidbody rb = bulletClone.GetComponent<Rigidbody>();
        BulletControler bc = bulletClone.GetComponent<BulletControler>();
        bc.damage = damage;
        //Add force so bullet moves forward with the speed "bulletSpeed"
        rb.AddRelativeForce(new Vector3(-100, 0, 0) * bulletSpeed);
    }


    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        //Find all enemy objects for targeting
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        //Get spawnlocation for bullets on tower
        bulletSpawn = transform.Find("BulletSpawn").gameObject;
        //Find the range indicator and give it the right size
        rangeIndicator = transform.Find("Range").gameObject;
        rangeIndicator.transform.localScale = new Vector3(range, 2, range);
        //Set fireDelay so tower starts with cooldown instead of directly attacking
        fireDelay = fireRate;
    }


    void FixedUpdate()
    {
        //if tower has no target look for target within range
        if (target == null)
        {

            for (int i = 0; i < gameManager.Enemies.Count; i++)
            {
                if (gameManager.Enemies[i] != null)
                {
                    if (Vector3.Distance(gameManager.Enemies[i].transform.position, transform.position) < range / 2)
                    {
                        target = gameManager.Enemies[i];
                    }
                }
            }
        }
        //If tower has target aim for target
        if (target != null)
        {
            float angle = AngleBetweenPoints(transform.position, target.transform.position);
            transform.rotation = Quaternion.Euler(new Vector3(0f, angle, 0f));
            //If target is outside tower range set target on null so next target can be found
            if (Vector3.Distance(target.transform.position, transform.position) > range / 2)
            {
                target = null;
            }
        }


        //Decreases fireDelay for attack speed controle
        if (fireDelay > 0) fireDelay--;
        //If target has been found and fireDelay is 0, attack and reset fireDelay.
        if (fireDelay == 0 && target != null)
        {
            fireDelay = fireRate;
            Fire(target.transform.position);
        }

        //If tower is selected show range circle
        if (selected)
        {
            rangeIndicator.SetActive(true);
        }
        else
        {
            rangeIndicator.SetActive(false);
        }
    }

    //Used for aiming the tower
    float AngleBetweenPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(b.z - a.z, a.x - b.x) * Mathf.Rad2Deg;
    }
}
