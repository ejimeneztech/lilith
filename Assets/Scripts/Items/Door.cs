using UnityEngine;

public class Door : MonoBehaviour
{
    public string doorId;
    public bool isOpen = false;

    public GameObject interactionPromptUI;

    void Start()
    {
        if (interactionPromptUI != null)
        {
            interactionPromptUI.SetActive(false);
        }
    }

    public void ShowPrompt()
    {
        if (interactionPromptUI != null)
        {
            interactionPromptUI.SetActive(true);
        }
    }


    public void HidePrompt()
    {
        if (interactionPromptUI != null)
        {
            interactionPromptUI.SetActive(false);
        }
    }
    
    public void OpenDoor()
    {
        if (isOpen) return;
        isOpen = true;
        Debug.Log("Door" + gameObject.name + " is opened.");
        gameObject.SetActive(false);
    }

    
}
