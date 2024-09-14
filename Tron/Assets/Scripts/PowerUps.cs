using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{   
    public GameObject powerUpPrefab;  // Assign your prefab here
    public float spawnInterval = 5f;  // Time interval for spawning power-ups
    public Vector3 spawnAreaMin;      // Min x and y values for the spawn area
    public Vector3 spawnAreaMax;      // Max x and y values for the spawn area

    private void Start()
    {
        // InvokeRepeating(nameof(SpawnPowerUp), 2f, spawnInterval);
        for (int i = 0; i < 10; i++)
        {
            SpawnPowerUp();
        }
    }


    private void SpawnPowerUp()
    {
        // Generate random x and y values within the spawn area
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);

        // Snap to the nearest 0.25 value
        x = Mathf.Round(x * 4f) / 4f;
        y = Mathf.Round(y * 4f) / 4f;

        // Create the power-up at the snapped position
        Vector3 spawnPosition = new Vector3(x, y, transform.position.z);
        Instantiate(powerUpPrefab, spawnPosition, Quaternion.identity);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        // Check if the object that collided is the player
        if (collision.CompareTag("Player"))
        {
            // Call a function to apply the power-up effect
            ApplyPowerUpEffect(collision.gameObject);

            // Destroy the power-up object
            Destroy(gameObject);
        }
    }

    private void ApplyPowerUpEffect(GameObject player)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

        if (playerMovement != null)
        {
            playerMovement.speed = 10f;
        }

    }
}
