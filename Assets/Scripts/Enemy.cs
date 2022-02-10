using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //variable para controlar la velocidad del goomba
    public float speed = 4.5f;
    //variable para saber en que direccion se mueve en el eje X
    private int directionX = 1;

    //variable para almacener el rigidbody del enemigo
    private Rigidbody2D rigidBody;

    
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Añade velocidad en el eje x
        rigidBody.velocity = new Vector2(directionX * speed, rigidBody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D hit)
    {
        //si detecta collision con un objeto con tag Pared
        if(hit.gameObject.tag == "Pared")
        {
            Debug.Log("me he chocado");

            //si nos movemos a la derecha cambiara la direccion de movimiento a la izquierda
            if(directionX == 1)
            {
                directionX = -1;
            }
            //si nos movemos a la izquierda la cambia a la derecha
            else
            {
                directionX = 1;
            }

        }
        //si choca con el mario lo destruye
        else if(hit.gameObject.tag == "MuereMario")
        {
            Destroy(hit.gameObject);
        }
    }

}
