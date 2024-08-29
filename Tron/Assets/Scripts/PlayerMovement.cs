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
    private Vector3 moveAmount;


    private void Start()
    {
        //isMoving = true;
        moveX = 0f;
        moveY = 0.25f;
        rotateAngle = 0f;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveX = 0f;
            moveY = 0.25f;
            rotateAngle = 0f;

            Move();

        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveX = 0f;
            moveY = -0.25f;
            rotateAngle = 180f;

            Move();

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveX = -0.25f;
            moveY = 0f;
            rotateAngle = 90f;

            Move();

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveX = 0.25f;
            moveY = 0f;
            rotateAngle = -90f;

            Move();

        }


    }

    private void Move()
    {
        Vector3 currentPos = transform.position;
        

        moveAmount = new Vector3(moveX, moveY, 0f);
        Vector3 updatePos = currentPos + moveAmount;

        // transform.Translate(moveAmount);
        transform.position = updatePos;

        transform.eulerAngles = new Vector3(0f, 0f, rotateAngle);
    }
    
    /*private IEnumerator Move(Vector3 direction)
    {
        float elapsedTime = 0;

        originPos = transform.position;
        targetPos = originPos + direction;

        while (elapsedTime < speed)
        {
            transform.position = Vector3.Lerp(originPos, targetPos, elapsedTime);
            elapsedTime = speed * Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        // yield return new WaitForSeconds(1);

    }*/
}
