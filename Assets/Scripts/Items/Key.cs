using UnityEngine;

[CreateAssetMenu(menuName = "Item/Key")]
public class Key : Item
{
    public string targetDoorId;
    public override void Use(int slotIndex)
    {
        Debug.Log("Using key: " + itemName);
        
        // Get the door from PlayerInteraction
        Door nearbyDoor = PlayerInteraction.instance.GetNearbyDoor();
        
        if (nearbyDoor == null)
        {
            Debug.Log("No door nearby to unlock.");
            return;
        }

        if (nearbyDoor.doorId == targetDoorId)
        {
            nearbyDoor.OpenDoor();
            Debug.Log("Unlocked door with key: " + itemName);
            // InventoryManager.instance.DiscardItem(slotIndex);
            // InventoryManager.instance.inventoryScreen.SetActive(false);       
        }
        else
        {
            Debug.Log("Wrong key for this door!");
        }
    }
}