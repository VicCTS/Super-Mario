using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
    }
}
