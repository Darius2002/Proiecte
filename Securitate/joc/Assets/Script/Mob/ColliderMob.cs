using UnityEngine;

public class ColliderMob : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Pereti") && !collision.gameObject.CompareTag("Mob"))
        {
            Destroy(gameObject);
        }
    }
}
