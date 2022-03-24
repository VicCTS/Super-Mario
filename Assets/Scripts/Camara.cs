using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    //vectores para limitar la posicion de la camara en los ejes x e y
    public Vector2 limitX;
    public Vector2 limitY;

    public float interpolationRatio;

    // Update is called once per frame
    void FixedUpdate()
    {
        //posicion deseada de la camara
        Vector3 desiredPosition = target.position + offset;
        //limitamos el movimiento en el eje horizontal
        float limitedXPosition = Mathf.Clamp(desiredPosition.x, limitX.x, limitX.y);
        //limitamos el movimiento en el eje vertical
        float limitedYPosition = Mathf.Clamp(desiredPosition.y, limitY.x, limitY.y);
        //construimos un vector3 con los limites que hemos creado
        Vector3 limitedPostion = new Vector3(limitedXPosition, limitedYPosition, desiredPosition.z);
        //Interpolamos la posicion
        Vector3 lerpedPosition = Vector3.Lerp(transform.position, limitedPostion, interpolationRatio);

        transform.position = lerpedPosition;

    }
}
