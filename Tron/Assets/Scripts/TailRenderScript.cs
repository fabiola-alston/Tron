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
    private Vector3 playerPosUpdate;

    public SinglyLinkedList<Vector3> positions = new SinglyLinkedList<Vector3>();
    public static SinglyLinkedList<Vector3> globalPositions = new SinglyLinkedList<Vector3>();
    private SinglyLinkedList<GameObject> trailSquares = new SinglyLinkedList<GameObject>();

    void Start()
    {
        subUnit = unit / speed;

        playerPosUpdate = transform.position;

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
            trailSquares.AddLast(trailSquare);

            Debug.Log(positions.Length());

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

        if (transform.position != playerPosUpdate)
        {
            UpdateTrail();
            playerPosUpdate = transform.position;
        }
        
    }

    void UpdateTrail()
    {

        Vector3 playerPos = transform.position;

        positions.AddFirst(playerPos);
        positions.RemoveLast();

        Debug.Log("0: " + positions.Index(0) + "1: " + positions.Index(1) + "2: " + positions.Index(2) + "3: " + positions.Index(3));

        GameObject trailSquare = Instantiate(tilePrefab, playerPos, Quaternion.identity);
        trailSquares.AddFirst(trailSquare);

        Destroy(trailSquares.Index(trailLength));
        trailSquares.RemoveLast();

    }

    void SetDirection(float x, float y)
    {
        moveX = x;
        moveY = y;
    }
}
