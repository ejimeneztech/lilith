using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public string doorId;
    public bool isOpen = false;

    public bool requiresKey = true;

    //public float delay = 2f;

    public GameObject interactionPromptUI;

    public SpriteRenderer spriteRenderer;

    public Sprite openDoorSprite;
    public Sprite closedDoorSprite;
    

    private BoxCollider2D boxCollider2D;
    public BoxCollider2D triggercollider;
    
    //sfx
    public AudioClip openDoorSound;
    public AudioClip closeDoorSound;

    private AudioSource doorAudioSource;

    void Start()
    {
        doorAudioSource = GetComponent<AudioSource>();
            
        if (interactionPromptUI != null)
        {
            interactionPromptUI.SetActive(false);
        }

        spriteRenderer = GetComponent<SpriteRenderer>();

        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public void Interact()
    {
        //if door is open close it
        if (isOpen)
        {
            CloseDoor();
            return;
        }
        
        //Check if door is locked
        if (requiresKey)
        {
            PlayerInteraction.instance.PlayLockedSound();
            MessageManager.instance.ShowMessage("Door is Locked.");
            InventoryManager.instance.inventoryScreen.SetActive(true);
            InventoryManager.instance.isOpen = true;

        }
        else
        {
            OpenDoor();
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
    
    public virtual void OpenDoor()
    {
       isOpen = true;
       requiresKey = false; 

       if (openDoorSprite != null)
       {
           spriteRenderer.sprite = openDoorSprite;
           boxCollider2D.enabled = false;
           HidePrompt();

           if (openDoorSound != null)
           {
               doorAudioSource.PlayOneShot(openDoorSound);
           }
       }
       else
       {
           Debug.Log("Missing Open Door Sprite");
       }
       
       

    }

    public virtual void CloseDoor()
    {
        isOpen = false;

        if (closedDoorSprite != null)
        {
            spriteRenderer.sprite = closedDoorSprite;
            boxCollider2D.enabled = true;
            ShowPrompt();
            if (closeDoorSound != null)
            {
                doorAudioSource.PlayOneShot(closeDoorSound);
            }
        }
        else
        {
            Debug.Log("Missing Closed Door Sprite");
        }
        
    }
}
