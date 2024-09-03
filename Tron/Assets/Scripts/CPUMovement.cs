using LinkedListNS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private SinglyLinkedList<Vector3> globalPositions;

    void Start()
    {
        isMoving = true;
        subUnit = unit * speed;

        globalPositions = GlobalPositionsScript.globalPositions;

        moveX = 0f;
        moveY = -subUnit;
        rotateAngle = 0f;

        StartCoroutine(Clock());

    }

    void Update()
    {
        subUnit = unit * speed;

        if (isMoving)
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

        if ((position.x >= 10 || position.x <= -10) || (position.y >= 5 || position.y <= -5))
        {
            RandomTurn();
        }

        for (int i = 0; i < globalPositions.Length(); i++)
        {
            if (transform.position == globalPositions.Index(i))
            {
                Death();
            }
        }
    }


    private IEnumerator Clock()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            RandomTurn();
            
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
        int randomChoice = Random.Range(0, 4);

        if (isMoving)
        {
            switch (randomChoice)
            {
                case 0:
                    SetDirection(0f, subUnit, 0f);
                    break;

                case 1:
                    SetDirection(0f, -subUnit, 180f);
                    break;

                case 2:
                    SetDirection(-subUnit, 0f, 90f);
                    break;

                case 3:
                    SetDirection(subUnit, 0f, -90f);
                    break;

            }
        }
        
    }
}
