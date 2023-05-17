using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Hedef nesne
    public float smoothing = 5f; // Düzleştirme miktarı

    private Vector3 offset; // Kamera ve hedef arasındaki mesafe

    private void Start()
    {
        // Kamera ve hedef arasındaki mesafeyi hesapla
        offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        // Hedefin konumunu takip etmek için kamera konumunu hesapla
        Vector3 targetCamPos = target.position + offset;

        // Kamera pozisyonunu düzleştirerek hareket ettir
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
