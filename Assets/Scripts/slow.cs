using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class slow : MonoBehaviour

{
    
    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.Mouse0))//başlatır
        {
            RotateObject.rotateSpeed = 1f;


        }
        if (Input.GetKeyUp(KeyCode.Mouse0))//başlatır
        {
            RotateObject.rotateSpeed = 20f;


        }
        
    }
}
