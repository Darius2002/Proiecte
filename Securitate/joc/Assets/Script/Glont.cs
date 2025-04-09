using UnityEngine;

public class Glont : MonoBehaviour
{
    private Collider2D playerCollider;
    private Collider2D circleCollider;

    private void Start()
    {
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        circleCollider = GetComponent<Collider2D>();

        Physics2D.IgnoreCollision(playerCollider, circleCollider);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject); 
        }
    }
}
