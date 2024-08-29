using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridVisuals : MonoBehaviour
{
    public GameObject gridPrefab;
    private int rows = 21;
    private int columns = 41;
    private float gridSize = 50;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        Vector3 gridCenterOffset = new Vector3((columns - 1) * gridSize / 200f, (rows - 1) * gridSize / 200f, 0f);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                // Calculate position for each square, starting from bottom-left and centering the grid
                Vector3 position = new Vector3(col * gridSize / 100f, row * gridSize / 100f, 0f) - gridCenterOffset;

                // Instantiate the square
                GameObject square = Instantiate(gridPrefab, position, Quaternion.identity);

                // Optionally, parent the squares to the spawner object for better organization
                square.transform.SetParent(transform);
            }
        }
    }
}
