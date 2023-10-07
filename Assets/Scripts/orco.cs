using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orco : MonoBehaviour
{

    [SerializeField] private float velocidad = 1f;

    void Update()
    {
        this.gameObject.transform.position = this.gameObject.transform.position + (this.gameObject.transform.forward * this.velocidad * Time.deltaTime);
            
    }


}
