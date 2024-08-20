using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeCollider : MonoBehaviour
{

    [SerializeField]
    private float minX = -4.4f;
    [SerializeField]
    private float maxX = 4.4f;
    [SerializeField]
    private float minY = -4.4f;
    [SerializeField]
    private float maxY = 4.4f;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        // Clamp position inside the square
        position.x = Mathf.Clamp(position.x, minX, maxX);
        position.y = Mathf.Clamp(position.y, minY, maxY);

        transform.position = position;
    }
}
