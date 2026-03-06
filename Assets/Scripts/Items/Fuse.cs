using UnityEngine;

[CreateAssetMenu(menuName = "Item/Fuse")]
public class Fuse : Key
{
    public override bool Use(int slotIndex)
    {
        FuseBox fuseBox = FindFirstObjectByType<FuseBox>();
        if(fuseBox != null)
        {
            fuseBox.AddFuse();
            return true;
        }
        return false;
    }
}

