using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public string enemyName;
    public float damage;
    public float health;

    //movement follow player
    public float speed;

    public float detectionRange;

    private float distanceToPlayer;

    protected Transform player;

    void Start()
    {   //find and cache the player transform
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if(playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.Log("Player not found in the scene.");
        }
        
    }

    void Update()
    {
       
        Attack();
        
    }

   public virtual void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if(health <= 0)
        {
            Die();
        }
    }
   
   public virtual void Chase()
    {
        //move towards player
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    public virtual void Attack()
    {
         //calculate distance to player
        if(player != null)
        {
            distanceToPlayer = Vector2.Distance(transform.position, player.position);
            if(distanceToPlayer < detectionRange)
            {
                Chase();
            }

        }
    }

}

