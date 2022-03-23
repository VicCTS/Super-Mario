using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public Vector2 limitX;
    public Vector2 limitY;
    public float smothSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        float clampedX = Mathf.Clamp(desiredPosition.x, limitX.x, limitX.y);
        float clampedY = Mathf.Clamp(desiredPosition.y, limitY.x, limitY.y);
        Vector3 clampedPosition = new Vector3(clampedX, clampedY, desiredPosition.z);
        transform.position = Vector3.Lerp(transform.position, clampedPosition, smothSpeed);
        //transform.position = clampedPosition;
        //transform.position = target.position + offset;
    }
}
