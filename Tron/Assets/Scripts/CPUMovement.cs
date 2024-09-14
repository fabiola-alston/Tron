using LinkedListNS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QueueNS;
using StackNS;

public class CPUMovement : MonoBehaviour
{
    private float moveX;
    private static float moveY;
    private float rotateAngle;
    private bool isMoving;
    public float speed = 1f;
    private float unit = 0.25f; // standard is 0.25f
    private float subUnit = 0.25f; // standard at speed 1
    public float subUnitsTraveled;
    private Coroutine currentCoroutine;
    public Vector3 moveAmount;

    public int gas = 500;

    private TailRenderScript tailRenderer;

    public LinkedQueue<string> ItemQueue;
    public LinkedStack<string> PowerUpStack;


    enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    private Direction direction;

    void Start()
    {
        tailRenderer = gameObject.GetComponentInChildren<TailRenderScript>();
        isMoving = true;
        subUnit = unit * speed;

        // globalPositions = TailRenderScript.globalPositions;

        moveX = 0f;
        moveY = -subUnit;
        rotateAngle = 0f;

        int randomChoice = Random.Range(0, 2);

        if (randomChoice == 0)
        {
            direction = Direction.Up;
        }
        else
        {
            direction = Direction.Left;
        }
        

        StartCoroutine(Clock());

    }

    void Update()
    {
        subUnit = unit * speed;

        if (isMoving && gas != 0)
        {
            // Ensure we are not starting multiple coroutines
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


        Vector3 position = transform.position;


        if (((position.x + moveX >= 10 || position.x + moveX <= -10) || (position.y + moveY >= 5 || position.y + moveY <= -5)))
        {
            RandomTurn();
        }

        for (int i = 0; i < GlobalPositionsScript.globalPositions.Length(); i++)
        {
            if ((position.x - unit == GlobalPositionsScript.globalPositions.Index(i).x && position.y - unit == GlobalPositionsScript.globalPositions.Index(i).y))
            {   
                Death();
                return;
            }
        }
    }


    private IEnumerator Clock()
    {
        while (true)
        {
            RandomTurn();
            yield return new WaitForSeconds(5f);

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


        currentCoroutine = null;
    }

    private void Death()
    {
        isMoving = false;
        tailRenderer.DestroyTail();
        Destroy(gameObject, 0.5f);
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

    private void RandomTurn()
    {
        int randomChoice = Random.Range(0, 2);

        if (isMoving)
        {
            switch (direction)
            {
                case Direction.Up:
                    if (randomChoice == 0)
                    {
                        SetDirection(-subUnit, 0f, 90f); // left
                        direction = Direction.Left;
                    }
                    else if (randomChoice == 1)
                    {
                        SetDirection(subUnit, 0f, -90f); // right
                        direction = Direction.Right;
                    }
                    break;

                case Direction.Down:
                    if (randomChoice == 0)
                    {
                        SetDirection(-subUnit, 0f, 90f); // left
                        direction = Direction.Left;
                    }
                    else if (randomChoice == 1)
                    {
                        SetDirection(subUnit, 0f, -90f); // right
                        direction = Direction.Right;
                    }
                    break;

                case Direction.Left:
                    if (randomChoice == 0)
                    {
                        SetDirection(0f, subUnit, 0f); // up
                        direction = Direction.Up;
                    }
                    else if (randomChoice == 1)
                    {
                        SetDirection(0f, -subUnit, 180f); // down]
                        direction = Direction.Down;
                    }
                    break;

                case Direction.Right:
                    if (randomChoice == 0)
                    {
                        SetDirection(0f, subUnit, 0f); // up
                        direction = Direction.Up;
                    }
                    else if (randomChoice == 1)
                    {
                        SetDirection(0f, -subUnit, 180f); // down
                        direction = Direction.Down;
                    }
                    break;

            }

        }
    }
    public IEnumerator IncreaseSpeed()
    {
        speed = 3;
        yield return new WaitForSeconds(5f);
        speed = 1;
    }
}
