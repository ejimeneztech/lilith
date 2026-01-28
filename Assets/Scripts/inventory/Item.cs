using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public abstract class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;

    public int maxStack = 1;
    
    public abstract bool Use(int slotIndex);
}
