using UnityEngine;

public class FuseBox : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite noFuse;
    public Sprite oneFuse;
    public Sprite twoFuses;

    

    public void updateFuseBox(int fuseCount)
    {
        switch (fuseCount)
        {
            case 0:
                spriteRenderer.sprite = noFuse;
                break;
            case 1:
                spriteRenderer.sprite = oneFuse;
                break;
            case 2:
                spriteRenderer.sprite = twoFuses;
                break;
            default:
                Debug.LogWarning("Invalid fuse count: " + fuseCount);
                break;
        }
    }
}
