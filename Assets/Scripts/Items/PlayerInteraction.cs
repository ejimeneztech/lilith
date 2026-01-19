using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        Door door = other.GetComponent<Door>();
        
        if(door !=null)
        {
            Debug.Log("Near door: " + other.gameObject.name);
            InventoryManager.instance.inventoryScreen.SetActive(true);
        }
        
    }

   

    private void OnTriggerExit2D(Collider2D other)
    {
        InventoryManager.instance.inventoryScreen.SetActive(false);

    }
}
