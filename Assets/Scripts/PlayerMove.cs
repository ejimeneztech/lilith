using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private InputSystem_Actions input;

    // Sprites for different states. Used in FixedUpdate
    public Sprite frontSprite;
    public Sprite backSprite;

    public Sprite leftSprite;
    public Sprite rightSprite;

    private SpriteRenderer spriteRenderer;

    private Vector2 moveInput;

   

    void Awake()
    {
        input = new InputSystem_Actions();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //Listen for movement input
        input.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        input.Player.Move.canceled += ctx => moveInput = Vector2.zero;
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
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);

        // Change sprite based on movement direction
        if (moveInput.y > 0)
            spriteRenderer.sprite = backSprite;
        else if (moveInput.y < 0)
            spriteRenderer.sprite = frontSprite;
        else if (moveInput.x > 0)
            spriteRenderer.sprite = rightSprite;
        else if (moveInput.x < 0)
            spriteRenderer.sprite = leftSprite;
    }       
}