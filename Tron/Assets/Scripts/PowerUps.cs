using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{   
    public GameObject hyperSpeedPrefab;  // Assign your prefab here
    public GameObject bombPrefab;
    public GameObject gasChargePrefab;
    public GameObject growEstelaPrefab;
    public GameObject shieldPrefab;

    public Vector3 spawnAreaMin;      // Min x and y values for the spawn area
    public Vector3 spawnAreaMax;      // Max x and y values for the spawn area

    private void Start()
    {
        // InvokeRepeating(nameof(SpawnPowerUp), 2f, spawnInterval);
        for (int i = 0; i < 2; i++)
        {
            HyperSpeedSpawn();
            ShieldSpawn();
            GasChargeSpawn();
            BombSpawn();
            GrowEstelaSpawn();
        }
    }


    private void HyperSpeedSpawn()
    {
        // Generate random x and y values within the spawn area
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);

        // Snap to the nearest 0.25 value
        x = Mathf.Round(x * 4f) / 4f;
        y = Mathf.Round(y * 4f) / 4f;

        // Create the power-up at the snapped position
        Vector3 spawnPosition = new Vector3(x, y, transform.position.z);
        Instantiate(hyperSpeedPrefab, spawnPosition, Quaternion.identity);
        
    }

    private void ShieldSpawn()
    {
        // Generate random x and y values within the spawn area
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);

        // Snap to the nearest 0.25 value
        x = Mathf.Round(x * 4f) / 4f;
        y = Mathf.Round(y * 4f) / 4f;

        // Create the power-up at the snapped position
        Vector3 spawnPosition = new Vector3(x, y, transform.position.z);
        Instantiate(shieldPrefab, spawnPosition, Quaternion.identity);

    }

    private void GrowEstelaSpawn()
    {
        // Generate random x and y values within the spawn area
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);

        // Snap to the nearest 0.25 value
        x = Mathf.Round(x * 4f) / 4f;
        y = Mathf.Round(y * 4f) / 4f;

        // Create the power-up at the snapped position
        Vector3 spawnPosition = new Vector3(x, y, transform.position.z);
        Instantiate(growEstelaPrefab, spawnPosition, Quaternion.identity);

    }

    private void BombSpawn()
    {
        // Generate random x and y values within the spawn area
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);

        // Snap to the nearest 0.25 value
        x = Mathf.Round(x * 4f) / 4f;
        y = Mathf.Round(y * 4f) / 4f;

        // Create the power-up at the snapped position
        Vector3 spawnPosition = new Vector3(x, y, transform.position.z);
        Instantiate(bombPrefab, spawnPosition, Quaternion.identity);

    }

    private void GasChargeSpawn()
    {
        // Generate random x and y values within the spawn area
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);

        // Snap to the nearest 0.25 value
        x = Mathf.Round(x * 4f) / 4f;
        y = Mathf.Round(y * 4f) / 4f;

        // Create the power-up at the snapped position
        Vector3 spawnPosition = new Vector3(x, y, transform.position.z);
        Instantiate(gasChargePrefab, spawnPosition, Quaternion.identity);

    }



}
