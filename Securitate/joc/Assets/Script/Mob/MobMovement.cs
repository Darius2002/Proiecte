using UnityEngine;

public class MobMovement : MonoBehaviour
{
    private float moveSpeed = 3f;  
    private Transform playerTransform;
    private float avoidanceRadius = 2.5f;  
    private float minimumDistance = 2f;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (playerTransform != null)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;

            AvoidNearbyEnemies();

            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
        }
    }

    void AvoidNearbyEnemies()
    {
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Mob");

        foreach (GameObject enemy in allEnemies)
        {
            if (enemy != gameObject)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

                if (distanceToEnemy < minimumDistance)
                {
                    Vector3 directionAwayFromEnemy = transform.position - enemy.transform.position;
                    transform.position += directionAwayFromEnemy.normalized * avoidanceRadius * Time.deltaTime;
                }
            }
        }
    }
}
