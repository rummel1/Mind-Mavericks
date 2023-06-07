using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class saveposition : MonoBehaviour
{
    private Vector3 respawnPosition; // Yeniden doğma noktası

    // Karakterin öldüğü zaman çağrılan metod
    public void Die()
    {
        // Karakterin mevcut pozisyonunu sakla
        respawnPosition = transform.position;

        // Ölüm işlemleri veya animasyonları burada gerçekleştirilebilir

        // Karakteri yeniden doğur
        Respawn();
    }

    // Karakteri yeniden doğuran metod
    private void Respawn()
    {
        // Karakteri yeniden doğru konumuna yerleştir
        transform.position = respawnPosition;

        // Gerekli diğer işlemleri burada gerçekleştirebilirsiniz
    }
}
