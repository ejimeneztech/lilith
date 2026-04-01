using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string doorId;
    public bool isOpen = false;

    public bool requiresKey = true;

    public float delay = 2f;

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
        //if (isOpen) return;
        if (isOpen)
        {
           CloseDoor();
           return;
        }
        isOpen = true;
        requiresKey = false;
        if(openDoorSprite != null)
        {
            spriteRenderer.sprite = openDoorSprite;
            //HidePrompt();
            boxCollider2D.enabled = false;
            
            if (openDoorSound != null)
            {
                doorAudioSource.PlayOneShot(openDoorSound);
            }
                
            //StartCoroutine(CloseDoor(delay));
        }
        else
        {
            Debug.Log("Missing Open Door Sprite");
        }

    }

    public virtual void CloseDoor()
    {
        if(closedDoorSprite != null)
        {
            spriteRenderer.sprite = closedDoorSprite;
            boxCollider2D.enabled = true;
            isOpen = false;
            if (closeDoorSound != null)
            {
                doorAudioSource.PlayOneShot(closeDoorSound);
            }
            
        }
        else
        {
            Debug.Log("Missing closed door sprite");
        }
    }
}
