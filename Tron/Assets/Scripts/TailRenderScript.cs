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
    public int trailLength = 3;
    private float moveX;
    private float moveY;
    public float speed = 1f;
    private float unit = 0.25f; // standard is 0.25f
    private float subUnit = 0.25f; // standard at speed 1
    private Vector3 playerPosUpdate;


    // public static SinglyLinkedList<Vector3> globalPositions;

    public SinglyLinkedList<Vector3> positions = new SinglyLinkedList<Vector3>();
    private SinglyLinkedList<GameObject> tailObjects = new SinglyLinkedList<GameObject>();

    void Start()
    {
        // GlobalPositionsScript globalPosObject = gameObject.AddComponent<GlobalPositionsScript>();
        // globalPositions = GlobalPositionsScript.globalPositions;

        // globalPositions = GlobalPositionsScript.globalPositions;
        subUnit = unit / speed;

        playerPosUpdate = transform.position;

        moveX = 0f;
        moveY = subUnit;

        Vector3 playerPos = transform.position;
        Vector3 lastPlayerPos = playerPos;

        positions.AddFirst(playerPos);
        GlobalPositionsScript.globalPositions.AddFirst(new Vector3());

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
            GlobalPositionsScript.globalPositions.AddLast(lastPlayerPos);

            GameObject trailSquare = Instantiate(tilePrefab, playerPos, Quaternion.identity);
            tailObjects.AddFirst(trailSquare);

        }
        else
        {
            positions.AddFirst(playerPos);
            positions.RemoveLast();

            // global positions
            GlobalPositionsScript.globalPositions.AddFirst(lastPlayerPos);
            GlobalPositionsScript.globalPositions.RemoveLast();

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
        float time = 0f;

        for (int i = 0; i < tailObjects.Length() - 1; i++)
        {
            Destroy(this.tailObjects.Index(i), time);
            time += 0.1f;
        }
    }
}

