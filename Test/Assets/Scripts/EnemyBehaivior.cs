using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player;
    public float speed = 1f;
    public float roamSpeed = 0.5f;
    private Vector3 roamDirection;
    private int hp = 100;
    
    void Start()
    {
        // Initialize the roam direction
        roamDirection = GetRandomDirection();
    }

    void Update()
    {
        // Get all the objects with the "Player" tag
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        // Find the closest player
        float minDistance = Mathf.Infinity;
        foreach (GameObject p in players)
        {
            float distance = Vector3.Distance(transform.position, p.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                player = p.transform;
            }
        }

        // Calculate the direction to the player
        Vector3 direction = (player.position - transform.position).normalized;

        // Check if the enemy has line of sight to the player
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit))
        {
            if (hit.transform == player)
            {
                // The enemy has line of sight to the player, so move towards the player
                transform.position += direction * speed * Time.deltaTime;
            }
            else
            {
                // The enemy does not have line of sight to the player, so roam
                Roam();
            }
        }
        else
        {
            // The enemy does not have line of sight to the player, so roam
            Roam();
        }
    }

    void Roam()
    {
        // Move the enemy in the roam direction
        transform.position += roamDirection * roamSpeed * Time.deltaTime;

        // Occasionally change the roam direction
        if (Random.Range(0f, 1f) < 0.01f)
        {
            roamDirection = GetRandomDirection();
        }
    }

    Vector3 GetRandomDirection()
    {
        // Return a random direction
        return new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
    }

    
    void OnCollisionEnter(Collision other)
    {
        // Check if the enemy has touched the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Call a method on the player to decrease their HP
            player.GetComponent<Player>().DecreaseHP();
        }
    }
    
    public void TakeDamage(int damage)
    {
        hp -= damage;
        
        if (hp <= 0)
        {
            // Destroy the enemy
            Destroy(gameObject);
        }
    }
}