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



    void Awake()
    {
       Instance = this;
    }

   


   public void UpdateStatusUI(float healthRemaining, float totalHealth)
    {
        float ratio = healthRemaining / totalHealth;

        if (ratio >= 0.8f)
        {
            statusUI.sprite = normalSprite;
        }
        else if (ratio >= 0.6f)
        {
            statusUI.sprite = mediumSprite;
        
        }
        else if (ratio >= 0.3f)
        {
            statusUI.sprite = highSprite;
        }
        else
        {
            statusUI.sprite = dangerSprite;
            
        }
    }

   
}
