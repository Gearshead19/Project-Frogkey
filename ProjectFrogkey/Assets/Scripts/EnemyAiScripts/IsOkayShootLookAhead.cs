using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsOkayShootLookAhead : MonoBehaviour
{
    public Transform PlayerFroggy;
    public int ShootRange = 10;

    public float DelayShoot = 4.0f;
    public float DevideDelay = 1.0f;
    public GameObject Projectile;
    private bool NoShoot = false;

    public int ZDirectionShoot = 3;
    public int XDirectionShoot = 0;

    // Start is called before the first frame update
    void Start()
    {
        PlayerFroggy = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIFShoot();
    }

    void CheckIFShoot()
    {
        if (PlayerFroggy.transform.position.z > this.transform.position.z &&
            PlayerFroggy.transform.position.z < (this.transform.position.z + (ShootRange * 5)) &&
            PlayerFroggy.transform.position.x > (this.transform.position.x - 2) &&
            PlayerFroggy.transform.position.x < (this.transform.position.x + 2))
        {
            //shoot at player
            if (NoShoot == false)
            {
                ShootingAtPlayer();
            }
        }
    }

    void ShootingAtPlayer()
    {
            Instantiate(Projectile, this.transform.TransformPoint(XDirectionShoot, 0, ZDirectionShoot), this.gameObject.transform.rotation);
            NoShoot = true;
            Invoke("NotReadyToShootYet", (DelayShoot / DevideDelay));
    }

    void NotReadyToShootYet()
    {
        NoShoot = false;
    }
}
