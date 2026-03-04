using UnityEngine;

[CreateAssetMenu( menuName = "Item/Ammo")]
public class Ammo : Item
{
    public int count;
    public override bool Use(int slotIndex)
    {
        return true;
    }
}
