using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RotateObject : MonoBehaviour
{

    public static float rotateSpeed = 20f;

    void Update () {
        
        transform.Rotate (rotateSpeed * Time.deltaTime, 0, 0);
    }
}
