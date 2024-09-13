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
    private Coroutine currentCoroutine;
    private float unit = 0.25f; // standard is 0.25f
    private float subUnit = 0.25f; // standard at speed 1
    private float subUnitsTraveled;

    private SinglyLinkedList<Vector3> globalPositions;


    public float speed = 1f;
    public Vector3 moveAmount;

    private TailRenderScript tailRenderer;
    

    private void Start()
    {
        // starts game off
        isMoving = true;

        // sets subUnits (how many units will be traveled at a certain speed amount)
        subUnit = unit * speed;

        globalPositions = GlobalPositionsScript.globalPositions;

        moveX = 0f;
        moveY = subUnit;
        rotateAngle = 0f;

        tailRenderer = gameObject.GetComponent<TailRenderScript>();

    }

    void Update()
    {
        // constantly update current speed
        subUnit = unit * speed;

        // this starts the coroutine, and only starts another one once the last one is complete
        if (isMoving)
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
            Death();
        }

        // dies if car hits a grid position that is occupied by another player
        for (int i = 0; i < globalPositions.Length(); i++)
        {
            if (transform.position == globalPositions.Index(i))
            {
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
        Vector3 playerPos = transform.position;
        tailRenderer.DestroyTail();
        Destroy(gameObject, 0.5f);
    }


}
