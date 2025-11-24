using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip footstepClip;
    public float stepDelay = 0.4f;

    private float stepTimer = 0f;
    private Vector2 moveInput;

    // This method is called by your Input Action
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
        if (moveInput.magnitude > 0.1f) // player is moving
        {
            stepTimer += Time.deltaTime;
            if (stepTimer >= stepDelay)
            {
                audioSource.PlayOneShot(footstepClip);
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = stepDelay; // reset timer when stopped
        }
    }
}
