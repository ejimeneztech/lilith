using UnityEngine;

public class Door : MonoBehaviour
{
    private BoxCollider2D doorCollider;
    private bool isOpen = false;

    private void Awake()
    {
        doorCollider = GetComponent<BoxCollider2D>();

    }

    
    public void OpenDoor()
    {
        if (isOpen) return; // Door is already open 
        isOpen = true;
        doorCollider.enabled = false; // Disable collider to allow passage
        // Optionally, add door opening animation or sound here
        Debug.Log("Door opened.");
    }
}
