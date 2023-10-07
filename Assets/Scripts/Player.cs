using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] private CharacterController controlador;
    [SerializeField] private float velocidad = 6f;
    [SerializeField] private float gravedad = -9.8f;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal != 0f)
        {
            this.transform.rotation = Quaternion.Euler(0f, 90f * horizontal, 0f);
        }

        float vertical = Input.GetAxisRaw("Vertical");
        if (vertical != 0f)
        {
            if (vertical > 0f)
            {
                this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else
            {
                this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }

        Vector3 direccion = new Vector3(horizontal, 0f, vertical).normalized;
        Gravedad();

        

        controlador.Move(direccion * velocidad * Time.deltaTime);


    }

    private void Gravedad()
    {
        Vector3 vectorGravedad = new Vector3(0f, 0f, 0f);

        if (controlador.isGrounded)
        {
            //gravedad al estar en el suelo 
            vectorGravedad.y = -0.05f;
            controlador.Move(vectorGravedad);

        }
        else
        {
            //gravedad al estar en el aire
            vectorGravedad.y = gravedad;
            controlador.Move(vectorGravedad);
        }
    }


    public void pisarTrampa()
    {
        Debug.Log("Piso la trampa: GAME OVER");
        SceneManager.LoadScene(3);
    }

    public void chocaOrco()
    {
        Debug.Log("Choca contra Orco: GAME OVER");
        SceneManager.LoadScene(3);
    }

}
