using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
   public static bool canUseItems;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Door door = other.GetComponent<Door>();
        
        if(door !=null)
        {
            Debug.Log("Near door: " + other.gameObject.name);
        }
        
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        canUseItems = true;
        InventoryManager.instance.inventoryScreen.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        canUseItems = false;
    }
}
