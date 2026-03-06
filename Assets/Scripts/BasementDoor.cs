using UnityEngine;

public class BasementDoor : Door
{
    
   public FuseBox fuseBox;

    public override void OpenDoor()
    {
    

        if (fuseBox != null && fuseBox.fuseCount == 2)
        {
            base.OpenDoor();
            Debug.Log("The door is now open!");
        }
        else
        {
            Debug.Log("The door is locked. You need to insert 2 fuses to open it.");
        }
    }
    
    
}
