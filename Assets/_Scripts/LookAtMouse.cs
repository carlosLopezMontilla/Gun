using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public GameObject Front;
    public GameObject Left;
    public GameObject Right;
    public GameObject Back;


    private void Update()
    {
        Turning();
    }
    private void FixedUpdate()
    {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        print(difference);
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
         transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

         if (transform.eulerAngles.z >= 0 && transform.eulerAngles.z <= 44)
         {
             Front.SetActive(false);
             Left.SetActive(false);
             Right.SetActive(true);
             Back.SetActive(false);
         } 
         if (transform.eulerAngles.z >=130 && transform.eulerAngles.z <= 184)
         {
             Front.SetActive(false);
             Left.SetActive(true);
             Right.SetActive(false);
             Back.SetActive(false);
         }
         if (transform.eulerAngles.z >= 44 && transform.eulerAngles.z <= 130)
         {
             Front.SetActive(false);
             Left.SetActive(false);
             Right.SetActive(false);
             Back.SetActive(true);
         } 
         if (transform.eulerAngles.z >= 220 && transform.eulerAngles.z <= 340)
         {
             Front.SetActive(true);
             Left.SetActive(false);
             Right.SetActive(false);
             Back.SetActive(false);
         }


    }
    void Turning()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.right = direction;
    }
}
    