using UnityEngine;

[CreateAssetMenu(menuName = "Item/Key")]
public class Key : Item
{
    public string targetDoorId;
    
    public override void Use(int slotIndex)
    {
        Debug.Log("Using key: " + itemName);
        //Check if door is assigned and if it is the correct door to unlock
        if (DoorContext.currentDoor == null)
        {
            Debug.Log("No door in context to unlock.");
            return;
        }
        
        if(DoorContext.currentDoor.doorId == targetDoorId)
        {
            DoorContext.currentDoor.OpenDoor();
            Debug.Log("Unlocked door with key: " + itemName);
            InventoryManager.instance.DiscardItem(slotIndex);
            InventoryManager.instance.inventoryScreen.SetActive(false);       
        }
        else
        {
            Debug.Log("No door assigned to this key.");
        }
    }
}
