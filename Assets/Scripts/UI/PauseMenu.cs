using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private InputSystem_Actions input;
    private bool isPaused = false;

    void Awake()
    {
        input = new InputSystem_Actions();
    }

    void OnEnable()
    {
        input.Player.Enable();
    }

    void OnDisable()
    {
        input.Player.Disable();
    }

    void Update()
    {
        if (input.Player.Pause.WasPressedThisFrame())
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        isPaused = false;
        GameSceneManager.Instance.StartGame();
    }
}
