using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LinkedListNS;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class TailRenderScript : MonoBehaviour
{
    public GameObject tilePrefab;
    public GameObject car;
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

        if (car == null)
        {
            car = new GameObject();
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

    private void UpdateTrail()
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

    private void SetDirection(float x, float y)
    {
        moveX = x;
        moveY = y;
    }


    public void DestroyTail()
    {
        for (int i = 0; i < tailObjects.Length() - 1; i++)
        {
            Destroy(this.tailObjects.Index(i));
        }
    }
}

/*public class TailRenderer : MonoBehaviour 
{
    public int tailLength;
    private SinglyLinkedList<Vector3> positions = new SinglyLinkedList<Vector3>();
    public static SinglyLinkedList<Vector3> globalPositions = new SinglyLinkedList<Vector3>();
    private SinglyLinkedList<GameObject> tailObjects = new SinglyLinkedList<GameObject>();
    public GameObject squarePrefab;
    private Vector3 playerPosUpdate;

    // when instanced, will automatically do this for every instance
    void Start()
    {
        // adds players current position
        positions.AddFirst(transform.position); // adds to normal, private positions list
        globalPositions.AddFirst(new Vector3()); // adds to global positions list used by all players

        playerPosUpdate = transform.position;

    }

    // is called everytime there is a change in position
    public void UpdateTail(float moveX, float moveY)
    {
        Vector3 playerPos = transform.position;

        // last position player was in before the current one
        Vector3 lastPlayerPos = new Vector3(playerPos.x - moveX, playerPos.y - moveY, playerPos.z);

        // if game is starting out, 
        if (positions.Length() < tailLength + 1)
        {
            Debug.Log(positions.Length());
            positions.AddLast(lastPlayerPos);
            globalPositions.AddLast(lastPlayerPos);

            GameObject trailSquare = Instantiate(squarePrefab, playerPos, Quaternion.identity);
            tailObjects.AddFirst(trailSquare);

        }
        else
        {
            positions.AddFirst(playerPos);
            positions.RemoveLast();

            // global positions
            globalPositions.AddFirst(lastPlayerPos);
            globalPositions.RemoveLast();

            GameObject trailSquare = Instantiate(squarePrefab, playerPos, Quaternion.identity);
            tailObjects.AddFirst(trailSquare);

            Destroy(tailObjects.Index(tailLength));
            tailObjects.RemoveLast();

        }
    }

    // destroys tail entirely
    public void DestroyTail()
    {
        for (int i = 0; i < tailObjects.Length() - 1; i++)
        {
            Destroy(tailObjects.Index(i));
        }
    }

    public void CallOnUpdate(float moveX, float moveY)
    {
        if (transform.position != playerPosUpdate)
        {
            UpdateTail(moveX, moveY);
            playerPosUpdate = transform.position;
        }
    }
}
*/