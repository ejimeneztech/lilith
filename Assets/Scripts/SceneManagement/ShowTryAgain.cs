using System.Collections;
using UnityEngine;

public class ShowTryAgain : MonoBehaviour
{
    public GameObject tryAgainUI;
    public float delay = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
    //     tryAgainUI.SetActive(false);
        
    // }

    void OnEnable()
    {
        StartCoroutine(ShowTryAgainUI());
    }

    

    IEnumerator ShowTryAgainUI()
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Courutine should start now");
        tryAgainUI.SetActive(true);
    }
}
