using UnityEngine;

public class AttachCamTint : MonoBehaviour
{
    void Start()
    {
        Camera cam = Camera.main;
        Canvas canvas = GetComponent<Canvas>();

        if (canvas != null && cam != null)
        {
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.worldCamera = cam;
            canvas.planeDistance = 1f; // how far in front of the camera
            canvas.pixelPerfect = true;
            Debug.Log("Canvas successfully attached to main camera.");
        }
    }
}
