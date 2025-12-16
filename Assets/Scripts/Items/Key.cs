using UnityEngine;

[CreateAssetMenu(menuName = "Item/Key")]
public class Key : Item
{
    
    public override void Use()
    {
        Debug.Log($"Using key: {itemName} to unlock a door.");
    }
}
