using System.Collections;
using UnityEngine;
using QueueNS;
using StackNS;


public class PlayerMovement : MonoBehaviour
{
    // determine direction and movement
    private float moveX;
    private static float moveY;
    private float rotateAngle;

    // automatically set to true at start
    private bool isMoving;

    // starts movement coroutine
    private Coroutine currentCoroutine;

    // public speed, can be changed
    public float speed = 1f;

    // gas-o-meter :)
    public int gas = 500; 

    // standard amount of pixels (unity measure) that car will move
    private float unit = 0.25f; // standard is 0.25f

    // used to determine speed
    private float subUnit = 0.25f; // standard at speed 1

    // useed for movement coroutine
    private float subUnitsTraveled;
    public Vector3 moveAmount;

    // used in global variables and in rendering tail (both are linked)
    // private SinglyLinkedList<Vector3> globalPositions;
    public TailRenderScript tailRenderer;

    public LinkedQueue<int> ItemQueue;
    public LinkedStack<int> PowerUpStack;

    private void Start()
    {
        // starts game off
        isMoving = true;

        // sets subUnits (how many units will be traveled at a certain speed amount)
        subUnit = unit * speed;

        // globalPositions = TailRenderScript.globalPositions;

        moveX = 0f;
        moveY = subUnit;
        rotateAngle = 0f;

        tailRenderer = gameObject.GetComponentInChildren<TailRenderScript>();

    }

    void Update()
    {
        // constantly update current speed
        subUnit = unit * speed;

        // this starts the coroutine, and only starts another one once the last one is complete
        if (isMoving && gas != 0)
        {
            if (currentCoroutine == null)
            {
                currentCoroutine = StartCoroutine(ConstantMove());
            }
        }
        else if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
            currentCoroutine = null;
        }

        // positions is always updated with current car position
        Vector3 position = transform.position;

        // dies if car hits an edge
        if ((position.x >= 10 || position.x <= -10) || (position.y >= 5 || position.y <= -5))
        {
            tailRenderer.DestroyTail();
            Death();
        }

        // dies if car hits a grid position that is occupied by another player or itself
        for (int i = 0; i < GlobalPositionsScript.globalPositions.Length(); i++)
        {
            if (transform.position.x == GlobalPositionsScript.globalPositions.Index(i).x && transform.position.y == GlobalPositionsScript.globalPositions.Index(i).y)
            {
                tailRenderer.DestroyTail();
                Death();
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isMoving)
        {
            SetDirection(0f, subUnit, 0f);

        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && isMoving)
        {
            SetDirection(0f, -subUnit, 180f);

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && isMoving)
        {
            SetDirection(-subUnit, 0f, 90f);

        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && isMoving)
        {
            SetDirection(subUnit, 0f, -90f);

        }

    }


    private void SetDirection(float dirX, float dirY, float angle)
    {
        moveX = dirX;
        moveY = dirY;
        rotateAngle = angle;
        transform.eulerAngles = new Vector3(0f, 0f, rotateAngle);
        moveAmount = new Vector3(moveX, moveY, 0f);

        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
            currentCoroutine = StartCoroutine(ConstantMove());
        }

    }

    private IEnumerator ConstantMove()
    {
        Vector3 currentPos = transform.position;
    
        Vector3 updatePos = currentPos + moveAmount;

        subUnitsTraveled = 0f;

        while (subUnitsTraveled < unit)
        {
            transform.position = updatePos;
            subUnitsTraveled += Time.deltaTime;
            yield return null;
        }
        
        Vector3 playerPos = transform.position;

        gas--;


        currentCoroutine = null;
    }

    private void Death()
    {
        isMoving = false;
        Vector3 playerPos = transform.position;
        tailRenderer.DestroyTail();
        Destroy(gameObject, 0.5f);
    }

    public IEnumerator IncreaseSpeed()
    {
        speed = 3;
        yield return new WaitForSeconds(5f);
        speed = 1;
    }


}
