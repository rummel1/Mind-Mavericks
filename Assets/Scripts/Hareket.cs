using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hareket : MonoBehaviour
{
    public static float hiz = 5.0f; // hareket hızı

    void FixedUpdate()
    {
        // hareket etmek için yeni pozisyonu hesapla
        Vector3 pozisyon = transform.position;
        pozisyon.x += hiz * Time.deltaTime;

        // nesnenin pozisyonunu güncelle
        transform.position = pozisyon;
    }
}





