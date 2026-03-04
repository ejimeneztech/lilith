using UnityEngine;

public class BasicEnemy : Enemy
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Health playerHealth = collision.gameObject.GetComponent<Health>();
        if(playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
