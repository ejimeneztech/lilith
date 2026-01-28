using System.Collections;
using UnityEngine;


public class PlayerDeath : MonoBehaviour
{
    public GameObject bloodParticleEffect;
    public GameObject[] gorePrefabs;

    public GameObject gameOverUI;

    public AudioSource deathAudioSource;
    public AudioClip deathClip;

    public SpriteRenderer playerSpriteRenderer;
    public Animator playerAnimator; 

    public float duration = 0.3f;
    public float magnitude = 0.5f;
    
    private bool isDead = false;

    void Start()
    {
        gameOverUI.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            isDead = true;
            //Instantiate blood particle effect at player's position
            playerSpriteRenderer.sprite = null;
            playerAnimator.enabled = false;
            Instantiate(bloodParticleEffect, transform.position, Quaternion.identity);
            deathAudioSource.PlayOneShot(deathClip);

        
            //Destroy player object
            InventoryManager.instance.ClearInventory();
            Destroy(gameObject, deathClip.length);
            gameOverUI.SetActive(true);
            
            

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
                    goreRb.linearDamping = 3f;
                }
            }

            
        }
    }

}
