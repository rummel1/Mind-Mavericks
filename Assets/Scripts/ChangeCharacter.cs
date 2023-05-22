using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    public GameObject Character1;
    public GameObject Character2;
    public Transform changepoint1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Destroy(Character2);
            Change1(changepoint1);
            Debug.Log("1");
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Destroy(Character1);
            Change2(changepoint1);
            Debug.Log("2");
            
        }
    }
    void Change1(Transform changepoint1)
    {
        GameObject player1 = Instantiate(Character1, changepoint1.position, changepoint1.rotation);
        Rigidbody rb = player1.GetComponent<Rigidbody>();
        
    }
    void Change2(Transform changepoint1)
    {
        GameObject player2 = Instantiate(Character2, changepoint1.position, changepoint1.rotation);
        Rigidbody rb = player2.GetComponent<Rigidbody>();
        
    }
}
