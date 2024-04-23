using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player;
    public float speed = 1f;
    private int hp = 100;
    public GameObject[] waypoints;
    public int currentWaypoint = 0;
    
    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypoint].transform.position) < 0.1f)
        {
            currentWaypoint = (currentWaypoint +1) % waypoints.Length;
        }
        Vector3 direction = (waypoints[currentWaypoint].transform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        
        transform.LookAt(waypoints[currentWaypoint].transform.position);
        
        Debug.DrawRay(transform.position, direction * 6, Color.red);
        Debug.DrawRay(transform.position, transform.forward * 5, Color.blue);
    }

    
    void OnCollisionEnter(Collision other)
    {
        // Check if the enemy has touched the player
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Player>().DecreaseHP();
        }
    }
    
    public void TakeDamage(int damage)
    {
        hp -= damage;
        
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}