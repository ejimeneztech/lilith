using UnityEngine;

[CreateAssetMenu(menuName = "Item/Key")]
public class Key : Item
{
    public Door door;
    
    public override void Use()
    {
        //Check if door is assigned and if it is the correct door to unlock
        if (door != null)
        {
            door.OpenDoor();

        }
        else
        {
            Debug.Log("No door assigned to this key.");
        }
    }
}
