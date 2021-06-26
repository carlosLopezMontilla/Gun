using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
   
    void Update()
    {
        faceMouse();
    }
    void faceMouse()
    {
       
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mousePos.x - transform.position.x,
            mousePos.y - transform.position.y);

        transform.up = direction;
    }
}
