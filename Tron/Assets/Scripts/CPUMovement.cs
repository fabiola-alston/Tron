using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUMovement : MonoBehaviour
{
    //private bool isMoving;
    private Vector3 originPos, targetPos;
    private float speed = 3f;
    private Vector3 direction = Vector3.down;
    private Quaternion target = Quaternion.Euler(0, 0, 90);


    void Start()
    {
        // isMoving = true;
        StartCoroutine(Clock());

    }

    void Update()
    {
        StartCoroutine(Move(direction));

    }

    private IEnumerator Move(Vector3 direction)
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

    }

    private IEnumerator Clock()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            RandomTurn();
            
        }
        
    }

    private void RandomTurn()
    {
        int randomChoice = Random.Range(0, 4);

        switch (randomChoice)
        {
            case 0:
                direction = Vector3.up;
                target = Quaternion.Euler(0, 0, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, speed);
                break;

            case 1:
                direction = Vector3.left;
                target = Quaternion.Euler(0, 0, 90);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, speed);
                break;

            case 2:
                direction = Vector3.right;
                target = Quaternion.Euler(0, 0, -90);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, speed);
                break;

            case 03:
                direction = Vector3.down;
                target = Quaternion.Euler(0, 0, -180);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, speed);
                break;
        }
    }
}
