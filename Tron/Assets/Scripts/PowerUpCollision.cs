using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollision : MonoBehaviour
{
    // Start is called before the first frame update
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
        }

    }
}
