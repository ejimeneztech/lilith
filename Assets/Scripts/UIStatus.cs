using UnityEngine;
using UnityEngine.UI;


public class UIStatus : MonoBehaviour
{
    public static UIStatus Instance; 

    [Header("Status Images")]
    public Image statusUI;
    public Sprite normalSprite;
    public Sprite mediumSprite;
    public Sprite highSprite;
    public Sprite dangerSprite;

    private EnemySpawner currentSpawner;

    private bool dangerActive = false;

    void Awake()
    {
       Instance = this;
    }

    public void SetSpawner(EnemySpawner spawner) // Called by EnemySpawner in StartSpawn
    {
        if (currentSpawner != null)
        {
            currentSpawner.OnCountdownUpdated -= UpdateStatusUI;
        }

        currentSpawner = spawner;

        if (currentSpawner != null)
        {
            currentSpawner.OnCountdownUpdated += UpdateStatusUI;
        }
    }


    public void ClearSpawner() // Called by EnemySpawner in StopSpawn
    {
        if (currentSpawner != null)
        {
            currentSpawner.OnCountdownUpdated -= UpdateStatusUI;
            currentSpawner = null;
            statusUI.sprite = normalSprite;
            dangerActive = false;
        }
    }


    

    void UpdateStatusUI(float timeRemaining, float totalTime)
    {
        float ratio = timeRemaining / totalTime;

        if (dangerActive)
        {
            statusUI.sprite = dangerSprite;
            return;

        }

        if (ratio >= 0.8f)
        {
            statusUI.sprite = normalSprite;
        }
        else if (ratio >= 0.6f)
        {
            statusUI.sprite = mediumSprite;
            Debug.Log("Medium Status");
        }
        else if (ratio >= 0.1f)
        {
            statusUI.sprite = highSprite;
        }
        else
        {
            statusUI.sprite = dangerSprite;
            dangerActive = true;
        }
    }

    public void ResetDanger()
    {
        dangerActive = false;
    }
}
