using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticCollision : MonoBehaviour
{
    public static bool isGrounded = true;

    private Rigidbody _rb;

    
    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    
    public  void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
           
            
        }
         if (other.gameObject.CompareTag("Player1"))
         {
             _rb.mass = 0.3f;

         }
    }

    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player1"))
        {
            _rb.mass = 1f;

        }
    }
}
