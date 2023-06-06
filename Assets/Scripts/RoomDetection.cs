using UnityEngine;

public class RoomDetection : MonoBehaviour
{
    public GameObject characterToEnable; // Aktifleştirilecek karakterin referansını tutacak değişken

    private void OnTriggerEnter(Collider other)
    {
        // Oyuncu odaya girdiğinde diğer karakteri aktifleştiririz
        if (other.CompareTag("Player"))
        {
            characterToEnable.SetActive(true);
        }
    }
}