using UnityEngine;

[CreateAssetMenu(menuName = "Item/Smartphone")]
public class Smartphone :Item
{
    public override bool Use(int slotIndex)
    {
        Debug.Log("Trigger End Scene here");
        return true;
    }
}
