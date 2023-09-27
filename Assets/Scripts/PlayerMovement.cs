using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;

    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;

    public IEnumerator RotateLeft()
    {
        isRotatingLeft = true;

        for (int i = 0; i < speed; i++)
        {
            transform.Rotate(new Vector3(0, -1, 0));
            yield return 0;
        }

        isRotatingLeft = false;
    }

    public IEnumerator RotateRight()
    {
        isRotatingRight = true;

        for (int i = 0; i < speed; i++)
        {
            transform.Rotate(new Vector3(0, 1, 0));
            yield return 0;
        }

        isRotatingRight = false;
    }

    void Update()
    {
        if( Input.GetKey("w") )
        {
            this.gameObject.transform.position += transform.forward * Time.deltaTime * speed;
        }

        if(isRotatingLeft == false)
        {
            if (Input.GetKey("a"))
            {
                StartCoroutine(RotateLeft());
            }
        }

        if (Input.GetKey("s"))
        {
            this.gameObject.transform.position -= transform.forward * Time.deltaTime * speed;
        }

        if (isRotatingRight == false)
        {
            if (Input.GetKey("d"))
            {
                StartCoroutine(RotateRight());
            }
        }   
    }
}
