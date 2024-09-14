using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperspeedCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object that collided is the player
        if (collision.CompareTag("Player") || collision.CompareTag("CPU"))
        {
            // Call a function to apply the power-up effect
            ApplyPowerUpEffect(collision.gameObject);

            Debug.Log(collision.gameObject.name);

            // Destroy the power-up object
            Destroy(gameObject);
        }
    }
    private void ApplyPowerUpEffect(GameObject player)
    {
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

        if (playerMovement != null)
        {
            Debug.Log(player.name + "Hyperspeed Power Up");
        }

    }
}
