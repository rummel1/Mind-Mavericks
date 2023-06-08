using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckPoint : MonoBehaviour
{
    public CharacterController characterController;
    public Transform chracter;
    
    private Vector3 spawnPoint;
  
    void Start()
    {
        characterController = GetComponent<CharacterController>();
       
    }
    void Update()
    {
        
        if (characterController.transform.position.y < -20f)
        {
            characterController.enabled = false;  // CharacterController'ı devre dışı bırak
            spawn();
            characterController.enabled = true;   // CharacterController'ı tekrar etkinleştir
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        
        if (other.CompareTag("CheckPoint"))
        {
            spawnPoint = other.transform.position;
            
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            spawn();
            
            
            
            

        }
        else if (other.gameObject.CompareTag("Poison"))
        {
            spawn();
            
            
            

        }
        
    }
    private void spawn()
    {
        characterController.enabled = false;  // CharacterController'ı devre dışı bırak
        characterController.transform.position = spawnPoint;  // Karakteri spawn noktasına taşı
        characterController.enabled = true;
    }
}
