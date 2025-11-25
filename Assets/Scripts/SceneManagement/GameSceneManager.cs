using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public static GameSceneManager Instance;

    public string startScreen = "StartScreen";
    public string mainGame = "Living Room";
    public string introScene = "Intro";


    void Awake()
    {
        // Singleton pattern implementation. If an instance already exists, destroy the new one.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    public void StartGame()
    {
        SceneManager.LoadScene(introScene);
    }

    
}
