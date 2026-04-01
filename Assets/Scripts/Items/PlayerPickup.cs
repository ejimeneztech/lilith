using UnityEngine;

public class PlayerPickup : MonoBehaviour
{


    [Header("SFX")]
    public AudioClip pickupSound;
    private AudioSource audioSource;
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

        //Debug.Log("Picked up: " + itemData.item.itemName);
        MessageManager.instance.ShowMessage("Picked up: " + itemData.item.itemName);
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(pickupSound);

        if (InventoryManager.instance == null)
        {
            Debug.LogError("No InventoryManager assigned!");
            return;
        }

        if (InventoryManager.instance.IsInventoryFull() == true) // Check if inventory is full before adding item
        {
            //Debug.Log("Inventory is full!");
            MessageManager.instance.ShowMessage("Inventory is full!");
            return;
        }
        InventoryManager.instance.AddItem(itemData.item);
        Destroy(other.gameObject);

    } 


}
