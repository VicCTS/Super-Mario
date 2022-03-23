using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
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
        rBody.AddForce(transform.right * bulletSpeed , ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(gameObject);
        if(collider.gameObject.tag == "Goombas")
        {
            gameManager.DeathGoomba(collider.gameObject);
        }
    }
}
