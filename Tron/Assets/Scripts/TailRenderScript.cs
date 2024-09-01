using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LinkedListNS;

public class TailRenderScript : MonoBehaviour
{
    public GameObject tilePrefab;
    public int trailLength = 3;
    private float moveX;
    private float moveY;
    public float speed = 1f;
    private float unit = 0.25f; // standard is 0.25f
    private float subUnit = 0.25f; // standard at speed 1

    public ILinkedList<Vector3> positions = new SinglyLinkedList<Vector3>();
    private ILinkedList<GameObject> trailSquares = new SinglyLinkedList<GameObject>();

    void Start()
    {
        subUnit = unit / speed;

        moveX = 0f;
        moveY = subUnit;

        Vector3 playerPos = transform.position;
        Vector3 lastPlayerPos = playerPos;

        positions.AddFirst(playerPos);

        for (int i = 0; i < trailLength; i++)
        {
            lastPlayerPos = new Vector3(lastPlayerPos.x - moveX, lastPlayerPos.y - moveY, -2f);
            GameObject trailSquare = Instantiate(tilePrefab, lastPlayerPos, Quaternion.identity);
            positions.AddLast(lastPlayerPos);

        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SetDirection(0f, subUnit);

        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SetDirection(0f, -subUnit);

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SetDirection(-subUnit, 0f);

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SetDirection(subUnit, 0f);

        }

        UpdateTrail();
    }

    void UpdateTrail()
    {
        Vector3 playerPos = transform.position;

        positions.AddFirst(playerPos);
        positions.RemoveLast();

        // Vector3 lastPlayerPos = new Vector3(playerPos.x - moveX, playerPos.y - moveY, -2f);

        GameObject trailSquare = Instantiate(tilePrefab, playerPos, Quaternion.identity);

    }

    void SetDirection(float x, float y)
    {
        moveX = x;
        moveY = y;
    }
}
