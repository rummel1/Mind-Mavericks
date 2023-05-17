using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class hareket_test : MonoBehaviour
{
    public static float hiz1 = 5.0f; // hareket hızı

    void FixedUpdate()
    {
        // hareket etmek için yeni pozisyonu hesapla
        Vector3 pozisyon = transform.position;
        pozisyon.x += hiz1 * Time.deltaTime;

        // nesnenin pozisyonunu güncelle
        transform.position = pozisyon;
    }
}