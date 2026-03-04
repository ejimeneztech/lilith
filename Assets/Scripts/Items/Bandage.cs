using UnityEngine;

[CreateAssetMenu( menuName = "Item/Bandage")]
public class Bandage : Item
{
    public Health playerHealth;
    public float healAmount = 70f;
    public override bool Use(int slotIndex)
    {
        playerHealth.Heal(healAmount);
        return true;
    }
}
