using UnityEngine;
using TMPro;
using System.Collections;

public class MessageManager : MonoBehaviour
{
    public static MessageManager instance;
    public TextMeshProUGUI messageText;
    public float displayDuration = 2f;
    
    private Coroutine currentMessage;

    void Awake()
    {
        instance = this;
        messageText.gameObject.SetActive(true);
    }

    public void ShowMessage(string message)
    {
        if (currentMessage != null)
        {
            StopCoroutine(currentMessage);
        }

        currentMessage = StartCoroutine(DisplayMessage(message));
    }


    IEnumerator DisplayMessage(string message)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(displayDuration);
        messageText.gameObject.SetActive(false);
        currentMessage = null;
    }
}
