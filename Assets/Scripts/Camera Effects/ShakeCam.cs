using System.Collections;
using UnityEngine;

public class ShakeCam : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        //Get original position of the camera
        Vector3 originalPos = transform.localPosition;

        //Initialize elapsed time
        float elapsed = 0.0f;
        
        while (elapsed < duration)
        {
            //Generate random offset
            float offsetX = Random.Range(-1f, 1f) * magnitude;
            float offsetY = Random.Range(-1f, 1f) * magnitude;

            //Apply offset to camera position
            transform.localPosition = new Vector3(originalPos.x + offsetX, originalPos.y + offsetY, originalPos.z);

            //Increment elapsed time
            elapsed += Time.deltaTime;

            //Wait until next frame
            yield return null;
            
        }

        
    }
}