using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newposition : MonoBehaviour
{
    public  Transform changepoint;
    public GameObject Character1;
    public GameObject Character2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Character1.activeSelf)
        {
            changepoint.position = Character1.transform.position;
        }
        else if (Character2.activeSelf)
        {
            changepoint.position = Character2.transform.position;
        }
    }
}
