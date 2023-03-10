using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    private Transform target;
    private Enemy targetEnemy;
    

    [Header("General")]

    public float range = 15f;

    //[Header("Use Bullets (Default)")]
    //public GameObject bulletPrefab;
    //public float fireRate = 1f;
    //private float fireCountdown = 0f;

    //[Header("Use Glue Bullets")]
    //public bool useGlueBullet;

    [Header("Use Laser")]
    public bool useLaser = false;
    //public float damageOverTime = 10;
    //public float slowAmount = .5f;

    [Header("Keybinds")]
    public KeyCode tongueKey = KeyCode.E;
    


    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;


    [Header("Unity Setup Fields")]

    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;
    public Quaternion originalRotationValue; // declare this as a Quaternion
    float rotationResetSpeed = 1.0f;


    public Transform firePoint;
   

    // Start is called before the first frame update
    void Start()
    {
        originalRotationValue = partToRotate.transform.rotation;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistant = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistant)
            {
                shortestDistant = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistant <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotationValue, Time.time * rotationResetSpeed);

        }

    }


    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            //Will turn the Line Render off when target is out of view.
            if (useLaser)
            {
                if(lineRenderer.enabled)
                {

                    lineRenderer.enabled = false;
                    //impactEffect.Stop();
                }
            }


            return;
        }

        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        
        //else
        //{
        //    if (fireCountdown <= 0f)
        //    {
        //        Shoot();
        //        //WorkInProgress code for slowing enemies down upon getting git by glue.
        //        //if (useGlueBullet)
        //        //{
        //        //    Debug.Log("Sloooooow");
        //        //    targetEnemy.speed = targetEnemy.startSpeed - 10f;
        //        //}
        //        fireCountdown = 1f / fireRate;
                
        //    }

        //    fireCountdown -= Time.deltaTime;
            
        //}

    }
    void LockOnTarget()
    {
        //This rotates the Turrets Head towards the "Enemy" target.
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    //Remember this code can be used to attach things too. Can be used for other project in the future. 
    void Laser()
    {
        //targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        //targetEnemy.Slow(slowAmount);

        if (!lineRenderer.enabled && Input.GetKeyDown(tongueKey))
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            

           
        }
        if (lineRenderer.enabled && Input.GetKeyDown(tongueKey))
        {
            Debug.Log("This is happening!");
            lineRenderer.enabled = false;
            impactEffect.Stop();
            
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        //Rotates the ImpactEffect away from enemy.
        Vector3 dir = firePoint.position - transform.position;

        impactEffect.transform.position = target.position + dir.normalized;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);

        
    }
    
    void Shoot()
    {
        //GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //Bullet bullet = bulletGO.GetComponent<Bullet>();

    //    if (bullet != null)
    //    {
    //        bullet.Seek(target);
    //    }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }


}
