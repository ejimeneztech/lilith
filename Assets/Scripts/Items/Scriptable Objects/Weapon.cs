using UnityEngine;

[CreateAssetMenu( menuName = "Item/Weapon")]
public class Weapon : Item
{
    public float damage;

    public float range;

    public float fireRate;
    public override bool Use(int slotIndex)
    {
        return true;
    }
}
