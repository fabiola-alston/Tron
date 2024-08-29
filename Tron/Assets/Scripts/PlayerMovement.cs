using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{

    /*private bool isMoving;
    private Vector3 originPos, targetPos;
    private float speed = 5f;
    private Vector3 direction = Vector3.up;

    [SerializeField]
    private Vector3 playerPos; */

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
            //moveX = 0f;
            //moveY = 0.25f;
            rotateAngle = 0f;

            moveAmount = new Vector3(moveX, moveY, 0f);
            transform.Translate(moveAmount);
            transform.eulerAngles = new Vector3(0f, 0f, rotateAngle);

        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //moveX = 0f;
            //moveY = -0.25f;
            rotateAngle = 180f;

            moveAmount = new Vector3(moveX, moveY, 0f);
            transform.Translate(moveAmount);
            transform.eulerAngles = new Vector3(0f, 0f, rotateAngle);

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //moveX = -0.25f;
            //moveY = 0f;
            rotateAngle = 90f;

            moveAmount = new Vector3(moveX, moveY, 0f);
            transform.Translate(moveAmount);
            transform.eulerAngles = new Vector3(0f, 0f, rotateAngle);

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //moveX = 0.25f;
            //moveY = 0f;
            rotateAngle = -90f;

            moveAmount = new Vector3(moveX, moveY, 0f);
            transform.Translate(moveAmount);
            transform.eulerAngles = new Vector3(0f, 0f, rotateAngle);

        }


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
