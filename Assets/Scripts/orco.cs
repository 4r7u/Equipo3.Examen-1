using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orco : MonoBehaviour
{

    [SerializeField] private float velocidad = 1f;
    [SerializeField] private float recorrido = 4f;
    
    void Update()
    {
        this.gameObject.transform.position = this.gameObject.transform.position + (this.gameObject.transform.forward * this.velocidad * Time.deltaTime);
        
    }

    private void Awake()
    {
        Vector3 posicion_inicial = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        Vector3 posicion_final = posicion_inicial + (this.gameObject.transform.forward * recorrido);

        if (posicion_inicial == posicion_final)
        {
            Debug.Log("Fin Recorrido");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            other.gameObject.GetComponent<Player>().chocaOrco();
        }

        if(other.gameObject.GetComponent<orco>() != null)
        {
            this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="carril")
        velocidad *= -1;
        this.transform.rotation = Quaternion.Euler(0f, this.transform.rotation.y*-1, 0f);
    }

}
