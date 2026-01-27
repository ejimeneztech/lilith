using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public static PlayerInteraction instance;
    
    [Header("Interaction Settings")]
    public UnityEngine.InputSystem.Key interactKey = UnityEngine.InputSystem.Key.E;
    
    private Door nearbyDoor;


    void Awake()
    {
        instance = this;
    }

    // Simple getter so Key can check which door we're near
    public Door GetNearbyDoor()
    {
        return nearbyDoor;
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
        // If near a door, open inventory to use keys
        if (nearbyDoor != null)
        {
            Debug.Log("Interacting with door: " + nearbyDoor.doorId);
            InventoryManager.instance.inventoryScreen.SetActive(true);
            InventoryManager.instance.isOpen = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check for door
        Door door = other.GetComponent<Door>();
        if (door != null)
        {
            nearbyDoor = door;
            Debug.Log("Near door: " + door.doorId + " - Press " + interactKey + " to interact");
            return;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Clear door reference
        Door door = other.GetComponent<Door>();
        if (door != null && door == nearbyDoor)
        {
            nearbyDoor = null;
            Debug.Log("Left door area");
        }
    }
}