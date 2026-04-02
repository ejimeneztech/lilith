using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public static PlayerInteraction instance;
    
    [Header("Interaction Settings")]
    public UnityEngine.InputSystem.Key interactKey = UnityEngine.InputSystem.Key.E;
    
    private IInteractable nearbyInteractable;
    private Door nearbyDoor;

    public AudioClip lockedDoorSound;
    private AudioSource doorAudioSource;


    void Awake()
    {
        instance = this;
        doorAudioSource = GetComponent<AudioSource>();
    }

    // Simple getter so Key can check which door we're near
    public Door GetNearbyDoor()
    {
        return nearbyDoor;
    }


    public void PlayLockedSound()
    {
        if (lockedDoorSound != null)
        {
            doorAudioSource.PlayOneShot(lockedDoorSound);
        }
        
    }
    void Update()
    {
        // Check for interact key press
        if (Keyboard.current[interactKey].wasPressedThisFrame)
        {
            TryInteract();
        }
    }

    private void TryInteract()
    {
        if (nearbyInteractable != null)
        {
            nearbyInteractable.Interact();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {
            nearbyInteractable = interactable;
            interactable.ShowPrompt();


            Door door = other.GetComponent<Door>();
            if (door != null)
            {
                nearbyDoor = door;
            }
        }
        
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();

        if (interactable != null && interactable == nearbyInteractable)
        {
            nearbyInteractable.HidePrompt();
            nearbyInteractable = null;
            nearbyDoor = null;
        }
    }
}