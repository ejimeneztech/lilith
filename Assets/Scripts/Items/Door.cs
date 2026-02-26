using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string doorId;
    public bool isOpen = false;

    public bool requiresKey = true;

    private float delay = 2f;

    public GameObject interactionPromptUI;

    public SpriteRenderer spriteRenderer;

    public Sprite openDoorSprite;
    public Sprite closedDoorSprite;
    

    private BoxCollider2D boxCollider2D;

    void Start()
    {
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
    
    public void OpenDoor()
    {
        if (isOpen) return;
        isOpen = true;
        requiresKey = false;
        if(openDoorSprite != null)
        {
            spriteRenderer.sprite = openDoorSprite;
            HidePrompt();
            boxCollider2D.enabled = false;
            StartCoroutine(CloseDoor(delay));
        }
        else
        {
            Debug.Log("Missing Open Door Sprite");
        }

    }


    IEnumerator CloseDoor(float time)
    {
        yield return new WaitForSeconds(time);

        if(closedDoorSprite != null)
        {
            spriteRenderer.sprite = closedDoorSprite;
            boxCollider2D.enabled = true;
            isOpen = false;
        }
        else
        {
            Debug.Log("Missing closed door sprite");
        }
        
    }

    
}
