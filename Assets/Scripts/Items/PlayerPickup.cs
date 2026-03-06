using UnityEngine;

public class PlayerPickup : MonoBehaviour
{


    //public InventoryManager inventoryManager;
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

        if (InventoryManager.instance == null)
        {
            Debug.LogError("No InventoryManager assigned!");
            return;
        }

        if (InventoryManager.instance.IsInventoryFull() == true) // Check if inventory is full before adding item
        {
            Debug.Log("Inventory is full!");
            return;
        }
        InventoryManager.instance.AddItem(itemData.item);
        Destroy(other.gameObject);

    } 


}
