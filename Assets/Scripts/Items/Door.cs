using UnityEngine;

public class Door : MonoBehaviour
{
    public string doorId;
    public bool isOpen = false;
    public void OpenDoor()
    {
        if (isOpen) return;
        isOpen = true;
        Debug.Log("Door" + gameObject.name + " is opened.");
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DoorContext.currentDoor = this;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Door context cleared: " + doorId);
            if(DoorContext.currentDoor == this)
                DoorContext.currentDoor = null;
            
        }
    }
}
