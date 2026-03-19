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

    private float timeOutOfRange = 0f;

    public float giveUpTime = 2f;
    
    //patrol data
    private Vector2 patrolTarget;
    private bool hasPatrolTarget = false;
    
    private float patrolTime = 0f;
    public float patrolDuration = 5f;
    public float patrolRadius = 5f;
    
    //idle data
    private float idleTime = 0f;
    public float idleDuration = 3f;
    
    
    
    //states
    public enum EnemyState
    {
        Idle,
        Chase,
        Patrol,
    }
    
    public EnemyState currentState = EnemyState.Idle;
    
    //animation
    protected Animator animator;

    void Start()
    {   
        
        //find and cache the player transform

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
        if (player != null)
        {
            distanceToPlayer = Vector2.Distance(transform.position, player.position);
        
            switch (currentState)
            {
                case EnemyState.Idle:
                    Idle();
                    break;
                case EnemyState.Patrol:
                    Patrol();
                    break;
                case EnemyState.Chase:
                    Chase();
                    break;
            }
        }
    }

  

    public virtual void Idle()
    {
        moveDirection = Vector2.zero;
        animator.SetBool("IsMoving", false);
        //after a few seconds, patrol
        idleTime += Time.deltaTime;

        if (idleTime >= idleDuration)
        {
            
            currentState = EnemyState.Patrol;
            idleTime = 0f;
            
            Vector2 randomCircle = UnityEngine.Random.insideUnitCircle * patrolRadius;
            patrolTarget = (Vector2)transform.position + randomCircle; //typecast to convert vector3 to vector2
            hasPatrolTarget = true;
        }
    }
    
    
    public virtual void Patrol()
    {
        if (hasPatrolTarget)
        {
            patrolTime += Time.deltaTime;
            
            moveDirection = (patrolTarget - (Vector2)transform.position).normalized;
            
            UpdateMoveAnim();
           
            //move toward target

            transform.position = Vector2.MoveTowards(transform.position, patrolTarget, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, patrolTarget) <= 0.1f || patrolTime >= patrolDuration)
            {
                patrolTime = 0f;
                currentState = EnemyState.Idle;
                hasPatrolTarget = false;
            }
            //transition to idle or chase
            if (distanceToPlayer <= detectionRange)
            {
                patrolTime = 0f;
                currentState = EnemyState.Chase;
            }
            
        }
        
        
    }
    
    
   public virtual void Chase()
    {
        //calculate direction to load corresponding animation
        moveDirection = (player.position - transform.position).normalized;

        UpdateMoveAnim();
        
        //move towards player
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if (distanceToPlayer >= detectionRange)
        {
            currentState = EnemyState.Idle;
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
    
    public virtual void UpdateMoveAnim()
    {
        //snap direction
        SnapDirection();

        animator.SetFloat("moveX", moveDirection.x); //map animator parameters
        animator.SetFloat("moveY",moveDirection.y );
        animator.SetBool("IsMoving", true);
    }
    

}

