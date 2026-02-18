using UnityEngine;

public class BasicEnemy : Enemy
{
    private Rigidbody2D rb;

    //animation
    private Animator animator;


    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
}
