using UnityEngine;
using UnityEngine.SceneManagement;
public class Retry : MonoBehaviour
{
    
    // Update is called once per frame
    public void RetryGame()
    {
        SceneManager.LoadScene("Living Room");
    }

    
}
