using UnityEngine;

public class PlayerPickup : MonoBehaviour
{


    public InventoryManager inventoryManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("PickUp"))
            return;

        ItemData itemData = other.GetComponent<ItemData>();
        if (itemData == null)
        {
            Debug.LogError("No ItemPickup found!");
            return;
        }

        Debug.Log("Picked up: " + itemData.item.itemName);

        if (inventoryManager == null)
        {
            Debug.LogError("No InventoryManager assigned!");
            return;
        }
        
        inventoryManager.AddItem(itemData.item);
        Destroy(other.gameObject);

    } 
}
