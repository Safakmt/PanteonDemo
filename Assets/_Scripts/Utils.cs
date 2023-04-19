using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Utils : MonoBehaviour
{

    public static Vector2 GetMouseWorldPos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousepos2D = new(mousePos.x, mousePos.y);
        return mousepos2D;
    }
}
