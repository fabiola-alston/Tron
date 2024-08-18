using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GridMovement : MonoBehaviour
{

    private bool isMoving;
    private Vector3 originPos, targetPos;
    private float speed = 500f;
    private Vector3 direction = Vector3.up;

    private void Start()
    {
        isMoving = true;
    }

    void Update()
    {
        StartCoroutine(Move(direction));


        if (Input.GetKey(KeyCode.LeftArrow) && isMoving)
        {
            direction = Vector3.left;

            Quaternion target = Quaternion.Euler(0, 0, 90);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow) && isMoving)
        {
            direction = Vector3.right;

            Quaternion target = Quaternion.Euler(0, 0, -90);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow) && isMoving)
        {
            direction = Vector3.down;

            Quaternion target = Quaternion.Euler(0, 0, -180);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow) && isMoving)
        {
            direction = Vector3.up;

            Quaternion target = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, speed * Time.deltaTime);
        }

    }
    
    private IEnumerator Move(Vector3 direction)
    {
        float elapsedTime = 0;

        originPos = transform.position;
        targetPos = originPos + direction;

        while (elapsedTime < speed)
        {
            transform.position = Vector3.Lerp(originPos, targetPos, (elapsedTime / speed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        yield return new WaitForSeconds(1);

    }
}
