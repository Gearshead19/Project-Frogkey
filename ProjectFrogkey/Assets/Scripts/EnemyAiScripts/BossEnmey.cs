using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnmey : MonoBehaviour
{
    public Transform PlayerFroggy;
    public int ShootRange = 20;

    public float DelayShoot = 4.0f;
    public float DevideDelay = 1.0f;
    public GameObject Projectile;
    private bool NoShoot = false;
    private int how_many_shoots = 1;

    public int projectile_spawn_range = 5;
    public int High = 2; //height over boss

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
        if (Vector3.Distance(PlayerFroggy.transform.position, this.transform.position) > projectile_spawn_range)
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
        for (int i = 0; i < how_many_shoots; i++)
        {
            Instantiate(Projectile, this.transform.TransformPoint(XDirectionShoot + Random.Range(-projectile_spawn_range, projectile_spawn_range), (this.transform.position.y + High), ZDirectionShoot + Random.Range(-projectile_spawn_range, projectile_spawn_range)), this.gameObject.transform.rotation);
            NoShoot = true;
            Invoke("NotReadyToShootYet", (DelayShoot / DevideDelay));
        }
        
    }

    void NotReadyToShootYet()
    {
        NoShoot = false;
    }
}
