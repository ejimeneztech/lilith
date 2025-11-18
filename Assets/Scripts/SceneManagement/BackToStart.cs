using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToStart : MonoBehaviour
{
    public void GoToStartScreen()
    {
        SceneManager.LoadScene("Start Screen");
    }
}
