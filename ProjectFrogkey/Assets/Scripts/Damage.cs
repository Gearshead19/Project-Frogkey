using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This damage script is only used for damage calculation.
/// It takes the Health of objects and when collided, they'll reduce the total
/// If it's less than or equal to 0, it'll disappear
/// </summary>
public class Damage : MonoBehaviour
{
    float bulletDamage = 10f;
    public EnemyHealth enemyHealth;

    /// <summary>
    /// When it collides with an enemy, this method will reduce their health. For testing, it'll make it disappear.
    /// After testing it'll temporarily deal 10 damage.
    /// It may have a null reference exception right now.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyHealth.currentEnemyHealth = enemyHealth.HealthPoints - bulletDamage;
            Debug.Log("Enemy eliminated");
            Debug.Log(enemyHealth.currentEnemyHealth);
            other.gameObject.SetActive(false);
        }
    }
}
