using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveControl : MonoBehaviour
{
    [SerializeField]
    private float _cameraDragSpeed;
    [SerializeField]
    private int _dragBorderPixel;

    void Update()
    {
        Vector3 movementVector = transform.position;

        if (Input.mousePosition.x >= Screen.width - _dragBorderPixel)
        {
            movementVector.x += _cameraDragSpeed * Time.deltaTime ;
        }
        if (Input.mousePosition.x <= _dragBorderPixel)
        {
            movementVector.x -= _cameraDragSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.y >= Screen.height - _dragBorderPixel)
        {
            movementVector.y += _cameraDragSpeed * Time.deltaTime;
        }
        if (Input.mousePosition.y <= _dragBorderPixel)
        {
            movementVector.y -= _cameraDragSpeed * Time.deltaTime;
        }

        movementVector.x = Mathf.Clamp(movementVector.x, -10, 10);
        movementVector.y = Mathf.Clamp(movementVector.y, -10, 5);
        transform.position = movementVector;
    }
}
