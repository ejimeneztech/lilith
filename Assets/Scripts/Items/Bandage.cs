using UnityEngine;

[CreateAssetMenu( menuName = "Item/Bandage")]
public class Bandage : Item
{
   public float healAmount = 70f;
    public override bool Use(int slotIndex)
    {
        Health playerHealth = FindFirstObjectByType<Health>();

         if(playerHealth != null)
        {
            playerHealth.Heal(healAmount);
            return true;
        }
            Debug.LogWarning("Player Health reference not set in Bandage item.");
            return false;
       
    }
}
