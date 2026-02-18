using UnityEngine;

public class RangedEnemy : Enemy
{
    [Header("Ranged Enemy Settings")]
    public float attackRange = 5f; // Stop this far from player
    public float shootCooldown = 1.5f;
    
    private float lastShootTime;

    public override void Chase()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        
        // If too close, back away
        if (distanceToPlayer < attackRange)
        {
            // Move away from player
            Vector2 directionAway = (transform.position - player.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, 
                (Vector2)transform.position + directionAway, 
                speed * Time.deltaTime);
        }
        // If too far, move closer
        else if (distanceToPlayer > attackRange + 1f)
        {
            Debug.Log("RangedEnemy is chasing the player.");
            base.Chase(); // Use normal chase to get closer
        }
        // If in range, shoot
        else
        {
            if (Time.time - lastShootTime > shootCooldown)
            {
                Shoot();
                lastShootTime = Time.time;
            }
        }
    }

    private void Shoot()
    {
        Debug.Log($"{enemyName} shoots at player!");
        // TODO: Instantiate projectile here
        // Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }   
}
