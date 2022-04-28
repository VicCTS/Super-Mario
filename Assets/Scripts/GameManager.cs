using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //MAnagers de sonido
    private SFXManager sfxManager;
    private BGMManager bgmManager;

    //variable para almacenar cantidad de monedas
    private int coins;
    //variable para el texto de monedas del canvas
    public Text coinsText;

    //bool para saber si tenemos el power up de disparar activado
    public bool shootPowerUp = false;
    //tiempo que durara el power up
    public float shootDuration = 5f;
    //tiempo transcurrido con el power up activado
    public float shootTimer = 0f;

    public List<GameObject> enemiesInScreen = new List<GameObject>();

    void Awake()
    {
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        bgmManager = GameObject.Find("BGMManager").GetComponent<BGMManager>();
    }

    void Update()
    {
        if(shootPowerUp == true)
        {
            if(shootTimer <= shootDuration)
            {
                shootTimer += Time.deltaTime;
            }
            else
            {
                shootPowerUp = false;
                shootTimer = 0f;
            }
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            KillAllEnemies();
        }
    }

    void KillAllEnemies()
    {
        /*for(int i = 0; i < enemiesInScreen.Count; i++)
        {
            Destroy(enemiesInScreen[i]);
        }*/

        /*int i = 0; 
        while(i < enemiesInScreen.Count)
        {
            Destroy(enemiesInScreen[i]);
            i++;
        }*/

        /*int i = 0;
        do
        {
            Destroy(enemiesInScreen[i]);
            i++;
        }while(i < enemiesInScreen.Count);*/

        foreach(GameObject enemy in enemiesInScreen)
        {
            Destroy(enemy);
        }

    }


    public void DeathMario()
    {
        sfxManager.DeathSound();
        bgmManager.StopBGM();
        Invoke("LoadMainMenu", 3);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }



    //Funcion para matar goombas
    public void DeathGoomba(GameObject goomba)
    {
        //variable para el animator del goomba
        Animator goombaAnimator;
        //variable para el script del goomba
        Enemy goombaScript;
        //variable para el collider
        BoxCollider2D goombaCollider;

        //asignamos las variable
        goombaScript = goomba.GetComponent<Enemy>();
        goombaAnimator = goomba.GetComponent<Animator>();
        goombaCollider = goomba.GetComponent<BoxCollider2D>();

        //cambiamos a la animacion de muerte
        goombaAnimator.SetBool("GoombaDeath", true);

        //cambiamos la variable del goomba a false
        goombaScript.isAlive = false;

        //Ajustamos el collider
        /*goombaCollider.size = new Vector2(1, 0.5f);
        goombaCollider.offset = new Vector2(0, 0.25f);*/

        //desactivo el collider
        goombaCollider.enabled = false;

        //destruimos el goomba
        Destroy(goomba, 0.3f);

        //llamamos la funcion del sonido de muerte del goomba
        sfxManager.GoombaSound();
    }

    public void Coin(GameObject moneda)
    {
        Destroy(moneda);
        sfxManager.MonedaSound();
        coins++;
        coinsText.text = "Coins: " + coins;
    }
}
