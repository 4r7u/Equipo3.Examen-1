using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    [SerializeField] private float speed = 20.0f;

    void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
