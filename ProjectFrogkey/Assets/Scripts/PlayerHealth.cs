using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int HealthPoints = 100;
    public int currentHealth;

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
        QucikReset();
        PlayerDead();
    }

    void QucikReset()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            MenuQuick.ReloadLevel();
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("I got shot");
            Destroy(collision.gameObject);
            //this.HealthPoints = this.HealthPoints - 1;
            currentHealth = currentHealth - 5;
            healthBar.SetHealth(currentHealth);

        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("I got harassed");
            //Destroy(other.gameObject);
            //this.HealthPoints = this.HealthPoints - 1;
            currentHealth = currentHealth - 3;
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
