using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //velocidad del proyectil
    public float bulletSpeed;

    private Rigidbody2D rBody;

    private GameManager gameManager;

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rBody.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //si chocamos con un goomba destruye la bala y el goomba
        if(collider.gameObject.tag == "Goombas")
        {
            //Destruye la bala
            Destroy(gameObject);
            //Destruye el goomba
            gameManager.DeathGoomba(collider.gameObject);
        }
        //si choca con una moneda que no haga nada
        if(collider.gameObject.tag == "Coin")
        {

        }
        
        else
        {
            Destroy(gameObject);
        }
    }
}
