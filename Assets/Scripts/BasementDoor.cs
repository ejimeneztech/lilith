using UnityEngine;

public class BasementDoor : Door
{
    public int fuseCount = 0;

    public void AddFuse()
    {
        fuseCount++;
        FuseBox fuseBox = FindFirstObjectByType<FuseBox>();
        if (fuseBox != null)
        {
            fuseBox.updateFuseBox(fuseCount);
        }
        if(fuseCount >= 2)
        {
            OpenDoor();
        }
    }
}
