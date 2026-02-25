using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    private InputSystem_Actions input;



    private Vector2 moveInput;


    //animation
    private Animator animator;

    public AudioSource footstepAudioSource;
    public AudioClip footstepClip;

    private float stepTimer = 0f;
    public float stepDelay = 0.4f; // time between footsteps





   

    void Awake()
    {
        input = new InputSystem_Actions();
        
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // Prevent rotation when bumping into objects

        animator = GetComponent<Animator>();
        

    }

    void OnEnable()
    {
        input.Player.Enable();
    }

    void OnDisable()
    {
        input.Player.Disable();
    }

    void Update()
    {
        moveInput = input.Player.Move.ReadValue<Vector2>();
        
        //add snapping logic
        SnapDirection();

         //update animator parameters
        animator.SetFloat("moveY", moveInput.y);
        animator.SetFloat("moveX", moveInput.x);    
        if(moveInput != Vector2.zero)
        {
            animator.SetBool("IsMoving", true);

        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
        
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
        
        //Handle footstep sounds
        if (moveInput != Vector2.zero)
        {
            stepTimer += Time.fixedDeltaTime;
            if (stepTimer >= stepDelay)
            {
                footstepAudioSource.PlayOneShot(footstepClip);
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = stepDelay; //reset timer when not moving
        }

       
    }

    void SnapDirection()
    {
        if(moveInput.magnitude > 0)
        {
            if(Mathf.Abs(moveInput.x) > Mathf.Abs(moveInput.y))
            {
                moveInput = new Vector2(Mathf.Sign(moveInput.x), 0);
            }
            else
            {
                moveInput = new Vector2(0,Mathf.Sign(moveInput.y));
            }
        }
    }       
}