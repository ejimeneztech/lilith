using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    public float TakeDamage(float damage)
    {
        currentHealth -= damage;
        UIStatus.Instance.UpdateStatusUI(currentHealth, maxHealth);
        return currentHealth;
    }

    public float Heal(float healAmount)
    {
        currentHealth += healAmount;
        UIStatus.Instance.UpdateStatusUI(currentHealth, maxHealth);
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        return currentHealth;
    }
}
