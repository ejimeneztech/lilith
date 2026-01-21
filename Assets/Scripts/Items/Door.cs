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

    
}
