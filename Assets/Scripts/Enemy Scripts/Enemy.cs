using System;
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

    protected Vector2 moveDirection;

    //animation
    protected Animator animator;

    void Start()
    {   //find and cache the player transform

        animator = GetComponent<Animator>();

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
       
        if(player != null)
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if(distanceToPlayer < detectionRange)
        {
            Chase();
        }
        else
        {
            animator.SetBool("IsMoving", false); // Only false when NOT chasing
        }
    }
        
        
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
        //calculate direction to load corresponding animation
        moveDirection = (player.position - transform.position).normalized;

        //snap direction
        SnapDirection();

        animator.SetFloat("moveX", moveDirection.x); //map animator parameters
        animator.SetFloat("moveY",moveDirection.y );
        animator.SetBool("IsMoving", true);
        
        //move towards player
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

   

    public virtual void SnapDirection()
    {
        if(Mathf.Abs(moveDirection.x) > Mathf.Abs(moveDirection.y))
        {
            moveDirection = new Vector2(Mathf.Sign(moveDirection.x), 0);
        } 
        else
        {
            moveDirection = new Vector2(0, Mathf.Sign(moveDirection.y));
        }
    }

}

