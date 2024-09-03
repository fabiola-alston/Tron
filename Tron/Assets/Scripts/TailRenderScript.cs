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
    public static SinglyLinkedList<Vector3> globalPositions;
    private SinglyLinkedList<GameObject> tailObjects = new SinglyLinkedList<GameObject>();

    void Start()
    {
        globalPositions = GlobalPositionsScript.globalPositions;
        subUnit = unit / speed;

        playerPosUpdate = transform.position;

        moveX = 0f;
        moveY = subUnit;

        Vector3 playerPos = transform.position;
        Vector3 lastPlayerPos = playerPos;

        positions.AddFirst(playerPos);
        globalPositions.AddFirst(new Vector3());

        /*for (int i = 0; i < trailLength; i++)
        {
            lastPlayerPos = new Vector3(lastPlayerPos.x - moveX, lastPlayerPos.y - moveY, -2f);
            GameObject trailSquare = Instantiate(tilePrefab, lastPlayerPos, Quaternion.identity);
            positions.AddLast(lastPlayerPos);
            trailSquares.AddLast(trailSquare);

            Debug.Log(positions.Length());

            // global positions add
            globalPositions.AddLast(lastPlayerPos);

        }*/
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
        Vector3 lastPlayerPos = new Vector3(playerPos.x - moveX, playerPos.y - moveY, playerPos.z);

        if (positions.Length() < trailLength + 1)
        {
            positions.AddLast(lastPlayerPos);
            globalPositions.AddLast(lastPlayerPos);

            GameObject trailSquare = Instantiate(tilePrefab, playerPos, Quaternion.identity);
            tailObjects.AddFirst(trailSquare);

        }
        else
        {
            positions.AddFirst(playerPos);
            positions.RemoveLast();

            // global positions
            globalPositions.AddFirst(lastPlayerPos);
            globalPositions.RemoveLast();

            GameObject trailSquare = Instantiate(tilePrefab, playerPos, Quaternion.identity);
            tailObjects.AddFirst(trailSquare);

            Destroy(tailObjects.Index(trailLength));
            tailObjects.RemoveLast();

        }

    }

    void SetDirection(float x, float y)
    {
        moveX = x;
        moveY = y;
    }


    public void DestroyTail()
    {
        for (int i = 0; i < tailObjects.Length() - 1; i++)
        {
            Destroy(tailObjects.Index(i));
        }
    }
}

public abstract class TailRenderer
{

}
