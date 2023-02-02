using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWalls : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    private bool moveRight = true;

    /// <summary>
    /// This Unity function is called every frame
    ///
    /// It is used to move the platform horizontally
    /// </summary>
    void Update()
    {
        if (transform.position.y > 25f)
        {
            moveRight = false;
        }

        if (transform.position.y < -25f)
        {
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime, transform.position.z);
        }
    }
}
