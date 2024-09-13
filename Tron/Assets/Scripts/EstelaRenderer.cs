using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LinkedListNS;

public class EstelaRenderer : MonoBehaviour
{
    public GameObject squarePrefab;
    public int tailLength;

    private SinglyLinkedList<Vector3> positions = new SinglyLinkedList<Vector3>();
    private SinglyLinkedList<GameObject> estelaParts = new SinglyLinkedList<GameObject>();
    public static SinglyLinkedList<Vector3> globalPositions = new SinglyLinkedList<Vector3>();

    public Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        /*if (playerPos != null)
        {
            positions.AddFirst(playerPos);
            globalPositions.AddFirst(new Vector3());
        }
        else
        {
            throw new System.Exception("Player position was not assigned.");
        }*/

    }

    public void StartCall()
    {
        if (playerPos != null)
        {
            positions.AddFirst(playerPos);
            globalPositions.AddFirst(new Vector3());
        }
        else
        {
            throw new System.Exception("Player position was not assigned.");
        }
    }

    public void UpdateEstela(float moveX, float moveY)
    {
        Vector3 lastPlayerPos = new Vector3(playerPos.x - moveX, playerPos.y - moveY, playerPos.z);

        if (positions.Length() < tailLength + 1)
        {
            positions.AddLast(lastPlayerPos);
            EstelaRenderer.globalPositions.AddLast(lastPlayerPos);

            GameObject estelaSquare = Instantiate(squarePrefab, playerPos, Quaternion.identity);
            estelaParts.AddFirst(estelaSquare);

        }
        else
        {
            positions.AddFirst(playerPos);
            positions.RemoveLast();

            // global positions
            EstelaRenderer.globalPositions.AddFirst(lastPlayerPos);
            EstelaRenderer.globalPositions.RemoveLast();

            GameObject estelaSquare = Instantiate(squarePrefab, playerPos, Quaternion.identity);
            estelaParts.AddFirst(estelaSquare);

            Destroy(estelaParts.Index(tailLength));
            estelaParts.RemoveLast();

        }

        Debug.Log(positions.Index(0));
    }

    public void DestroyTail()
    {
        for (int i = 0; i < estelaParts.Length() - 1; i++)
        {
            Destroy(this.estelaParts.Index(i));
        }
    }

    public void CreateSquare()
    {
        GameObject estelaSquare = Instantiate(squarePrefab, playerPos, Quaternion.identity);
    }
}
