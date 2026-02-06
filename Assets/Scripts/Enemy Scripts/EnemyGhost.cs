using UnityEngine;

public class EnemyGhost : MonoBehaviour
{
    Rigidbody2D rb;

    public float minSpeed = 50f;
    public float maxSpeed = 150f;

    public float health = 100f;

    
    void Start()
    {
        float randomSize = Random.Range(0.5f, 1.5f);
        transform.localScale = new Vector3(randomSize, randomSize, 1);

        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        Vector2 randomDirection = Random.insideUnitCircle;

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(randomDirection * randomSpeed);
    }

}
