using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newposition : MonoBehaviour
{
    public  Transform changepoint;
    public GameObject Character1;
    public GameObject Character2;
    public GameObject Character3;
    public GameObject Character4;
    public GameObject Character5;
    public GameObject Character6;
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
        else if (Character3.activeSelf)
        {
            changepoint.position = Character3.transform.position;
        }
        else if (Character4.activeSelf)
        {
            changepoint.position = Character4.transform.position;
        }
        else if (Character5.activeSelf)
        {
            changepoint.position = Character5.transform.position;
        }
        else if (Character6.activeSelf)
        {
            changepoint.position = Character6.transform.position;
        }
    }
}
