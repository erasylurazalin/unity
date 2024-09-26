using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour, IEnemy
{
    [HideInInspector]
    public float currentHealth;

    public float maxHealth = 10; // Enemy health
    public float moveSpeed = 3f; // Speed at which the enemy moves towards the player
    private Transform playerTransform;
    
    public enemyHealthBar healthBar;  // Reference to the HealthBar script
    NavMeshAgent navMeshAgent;

    void Start()
    {
        currentHealth = maxHealth;
        // Find the player's transform. Assumes the player has the tag "Player"
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player object not found! Make sure the player has the tag 'Player'.");
        }


        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;

    }
   
    void Update()
    {
       

        if (currentHealth > 0)
        {
            healthBar.SetHealth(currentHealth, maxHealth);
        }


        navMeshAgent.SetDestination(playerTransform.position);
    }


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        //future animation
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    
    void Death()
    {
        Destroy(gameObject);
        //future animation
    }    
}
