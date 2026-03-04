using UnityEngine;

[CreateAssetMenu( menuName = "Item/Slingshot")]
public class Slingshot : Weapon
{
    public Item ammo;

    public override bool Use(int slotIndex)
    {
        return true;
    }
}
