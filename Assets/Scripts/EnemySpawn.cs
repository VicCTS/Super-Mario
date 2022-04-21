using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform spawnPosition;
    public GameObject[] prefab;
    public int numberOfEnemies;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(numberOfEnemies == 0)
        {
            CancelInvoke();
        }
    }

    public void SpawnEnemy()
    {
        Instantiate(prefab[Random.Range(0, prefab.Length)], spawnPosition.position, spawnPosition.rotation);
        numberOfEnemies--;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "MuereMario")
        {
            InvokeRepeating("SpawnEnemy", 1, 1.5f);
        }
    }
}
