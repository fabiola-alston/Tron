using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;
using LinkedListNS;


public class PlayerMovement : MonoBehaviour
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
    
    // public static ILinkedList<Vector3> playerPositions = new SinglyLinkedList<Vector3>();


    public Vector3 moveAmount;

    private void Start()
    {
        isMoving = true;
        subUnit = unit * speed;

        moveX = 0f;
        moveY = subUnit;
        rotateAngle = 0f;

        /*Vector3 playerPos = transform.position;
        Vector3 lastPlayerPos = playerPos;

        for (int i = 0; i == 3; i++)
        {
            lastPlayerPos = new Vector3(lastPlayerPos.x - moveX, lastPlayerPos.y - moveY, 0f);
            playerPositions.AddLast(lastPlayerPos);

        }*/

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
            Death();
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

        if (Input.GetKeyDown(KeyCode.Q))
        {
            speed = 1f;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            speed = 2f;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            speed = 3f;
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

        // playerPositions.AddFirst(playerPos);
        // playerPositions.RemoveLast();

        // Debug.Log("X:" + playerPos.x + "Y: " + playerPos.y);


        currentCoroutine = null;
    }

    private void Death()
    {
        isMoving = false;
    }


}
