using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    
    public SpriteRenderer spriteRenderer;

    [Header("SFX")] 
    public AudioClip healSound;
    private AudioSource audioSource;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        audioSource = GetComponent<AudioSource>();
    }

    public float TakeDamage(float damage)
    {
        currentHealth -= damage;
        UIStatus.Instance.UpdateStatusUI(currentHealth, maxHealth);
        StartCoroutine((DamageFlash()));
        return currentHealth;
    }

     IEnumerator DamageFlash()
     { 
         spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.5f);
         spriteRenderer.color = Color.white;
    }

    public float Heal(float healAmount)
    {
        currentHealth += healAmount;
        audioSource.PlayOneShot(healSound);
        UIStatus.Instance.UpdateStatusUI(currentHealth, maxHealth);
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        return currentHealth;
    }
}
