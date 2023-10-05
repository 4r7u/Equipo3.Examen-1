using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;

    [Header("Subir escaleras:")]

    [SerializeField] GameObject stepRayUpper;
    [SerializeField] GameObject stepRayLower;
    [SerializeField] float stepHeight = 0.3f;
    [SerializeField] float stepSmooth = 0.1f;

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
            /*Movimiento*/
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

        /*escalar*/
        subirEscalon();

    }


    private void Awake()
    {
        stepRayUpper.transform.position = new Vector3(stepRayUpper.transform.position.x, stepHeight, stepRayUpper.transform.position.z);

    }

    void subirEscalon()
    {
        RaycastHit hitlower;
        if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(Vector3.forward), out hitlower, 0.2f))
        {
            RaycastHit hitUpper;
            if (Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(Vector3.forward), out hitUpper, 0.3f))
            {
                this.gameObject.transform.position -= new Vector3(0f, -stepSmooth, 0f);
            }
        }
    }

}
