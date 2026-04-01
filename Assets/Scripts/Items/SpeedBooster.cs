using UnityEngine;

[CreateAssetMenu( menuName = "Item/SpeedBooster")]
public class SpeedBooster : Item
{
    public float boostAmount = 5f;
    public float coolDown = 3f;

    
    private Coroutine speedBoostCoroutine;
    
    public override bool Use(int slotIndex)
    {
        PlayerMove playerMovement = FindFirstObjectByType<PlayerMove>();

        if(playerMovement != null)
        {
            if(speedBoostCoroutine != null)
            {
            playerMovement.StopCoroutine(speedBoostCoroutine);
            }
            
            speedBoostCoroutine = playerMovement.StartCoroutine(playerMovement.SpeedBoost(boostAmount, coolDown));
            return true;
        }
        else
        {
            Debug.LogWarning("PlayerMove reference not set in SpeedBooster item.");
            return false;
        }
        
    }
}
