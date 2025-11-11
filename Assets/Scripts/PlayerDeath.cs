using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject bloodParticleEffect;
    public GameObject[] gorePrefabs;

    public float duration = 0.3f;
    public float magnitude = 0.5f;  

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            //Trigger camera shake
            ShakeCam shakeCam = Camera.main.GetComponent<ShakeCam>();
            if (shakeCam != null)
            {
                StartCoroutine(shakeCam.Shake(0.3f, 0.5f));
            }

            //Instantiate blood particle effect at player's position
            Instantiate(bloodParticleEffect, transform.position, Quaternion.identity);

            //Destroy player object
            Destroy(gameObject);

            for (int i = 0; i < gorePrefabs.Length; i++)
            {
                //Generate random position around the player for each gore piece
                Vector3 spawnPos = transform.position + new Vector3(
                    Random.Range(-0.5f, 0.5f),
                    Random.Range(-0.5f, 0.5f),
                    0
                );

                //Instantiate gore piece
                GameObject gore = Instantiate(gorePrefabs[i], spawnPos, Quaternion.identity);
                
                //Apply physics to gore piece
                Rigidbody2D goreRb = gore.GetComponent<Rigidbody2D>();
                if (goreRb != null)
                {
                    //Apply random force to each gore piece
                    Vector2 randomForce = Random.insideUnitCircle * Random.Range(100f, 300f);
                    goreRb.AddForce(randomForce);
                }
                
            }

            
        }
    }
}
