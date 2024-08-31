using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    private float moveX;
    private float moveY;
    private float rotateAngle;
    private bool isMoving;
    public float speed = 1f;
    private float unit = 0.25f; // standard is 0.25f
    private float subUnit = 0.25f; // standard at speed 1
    public float subUnitsTraveled;

    public Vector3 moveAmount;

    private void Start()
    {
        isMoving = true;
        subUnit = unit * speed;

        moveX = 0f;
        moveY = subUnit;
        rotateAngle = 0f;
    }

    void Update()
    {
        if (isMoving)
        {
            StartCoroutine(ConstantMove());
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

    }


    private void SetDirection(float dirX, float dirY, float angle)
    {
        StopCoroutine(ConstantMove());
        moveX = dirX;
        moveY = dirY;
        rotateAngle = angle;
        transform.eulerAngles = new Vector3(0f, 0f, rotateAngle);
        moveAmount = new Vector3(moveX, moveY, 0f);

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
        
    }

    private void Death()
    {
        isMoving = false;
    }


}
