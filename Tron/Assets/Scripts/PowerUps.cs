using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{   

    // prefabs for different sprites for powerups and items
    public GameObject hyperSpeedPrefab;
    public GameObject bombPrefab;
    public GameObject gasChargePrefab;
    public GameObject growEstelaPrefab;
    public GameObject shieldPrefab;

    public Vector3 spawnAreaMin;
    public Vector3 spawnAreaMax;

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
        // generate random x and y values within the spawn area
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);

        // rounds to grid
        x = Mathf.Round(x * 4f) / 4f;
        y = Mathf.Round(y * 4f) / 4f;

       // instantiate object at position
        Vector3 spawnPosition = new Vector3(x, y, transform.position.z);
        Instantiate(hyperSpeedPrefab, spawnPosition, Quaternion.identity);
        
    }

    private void ShieldSpawn()
    {
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);

        x = Mathf.Round(x * 4f) / 4f;
        y = Mathf.Round(y * 4f) / 4f;

        Vector3 spawnPosition = new Vector3(x, y, transform.position.z);
        Instantiate(shieldPrefab, spawnPosition, Quaternion.identity);

    }

    private void GrowEstelaSpawn()
    {
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);

        x = Mathf.Round(x * 4f) / 4f;
        y = Mathf.Round(y * 4f) / 4f;

        Vector3 spawnPosition = new Vector3(x, y, transform.position.z);
        Instantiate(growEstelaPrefab, spawnPosition, Quaternion.identity);

    }

    private void BombSpawn()
    {
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);

        x = Mathf.Round(x * 4f) / 4f;
        y = Mathf.Round(y * 4f) / 4f;

        Vector3 spawnPosition = new Vector3(x, y, transform.position.z);
        Instantiate(bombPrefab, spawnPosition, Quaternion.identity);

    }

    private void GasChargeSpawn()
    {
        float x = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float y = Random.Range(spawnAreaMin.y, spawnAreaMax.y);

        x = Mathf.Round(x * 4f) / 4f;
        y = Mathf.Round(y * 4f) / 4f;

        Vector3 spawnPosition = new Vector3(x, y, transform.position.z);
        Instantiate(gasChargePrefab, spawnPosition, Quaternion.identity);

    }



}
