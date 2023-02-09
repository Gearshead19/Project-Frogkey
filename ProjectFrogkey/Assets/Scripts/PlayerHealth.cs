using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int HealthPoints = 100;
    public int currentHealth;
    public int invincible_factor = 1; //when turned to 0 it is invincible

    public HealthBar healthBar;
    
    
    public MenuEditQuick MenuQuick;

    
    // Start is called before the first frame update
    void Start()
    {
        //MenuQuick = gameObject.GetComponent<MenuEditQuick>();
        currentHealth = HealthPoints;
        healthBar.SetMaxHealth(HealthPoints);
         
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
           
            PlayerHealSelf();
        }
        
        QucikReset();
        PlayerDead();
    }
void OnQuickReset()
    {

    }

    void OnHeal()
    {

    }

    void QucikReset()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            MenuQuick.ReloadLevel();
        }

    }
    public void PlayerHealSelf()
    {
        if (Healing.healLimit == 0)
        {
           Debug.Log("No heals left!!");
            return;
        }
        if (currentHealth < 100)
            {
                currentHealth = currentHealth + 30;
                Healing.healLimit -= 1;

                healthBar.SetHealth(currentHealth);
            Debug.Log("You've Healed 30 HP!");

                if (currentHealth >= 100)
                {
                    currentHealth = 100;

                }
            }        
            
            else
            {
                Debug.Log("Your at MAX health!");
            }
        
        
    }
    void PlayerDead()
    {
        if(currentHealth <= 0)
        {
            //MenuQuick.ReloadLevel();
            SceneManager.LoadScene("Thanks_For_Playing");
           
        }
    }

    public void Player_Invincible(float time_for_invincible)
    {
        invincible_factor = 0;

        Invoke("Player_Deactive_Invincible", time_for_invincible);
    }

    protected void Player_Deactive_Invincible()
    {
        invincible_factor = 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("I got shot");
            Destroy(collision.gameObject);
            //this.HealthPoints = this.HealthPoints - 1;
            currentHealth = currentHealth - (5 * invincible_factor);
            healthBar.SetHealth(currentHealth);

        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("I got harassed");
            //Destroy(other.gameObject);
            //this.HealthPoints = this.HealthPoints - 1;
            currentHealth = currentHealth - (3 * invincible_factor);
            healthBar.SetHealth(currentHealth);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("I got shot");
            Destroy(other.gameObject);
            this.HealthPoints = this.HealthPoints - 1;

        }

        if(other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("I got harassed");
            //Destroy(other.gameObject);
            this.HealthPoints = this.HealthPoints - 1;
        }*/
    }
}
