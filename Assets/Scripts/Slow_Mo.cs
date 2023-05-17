using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_Mo : MonoBehaviour
{
    [Header("TimeControllerSettings")] 
    public float TimeScale;

    private float StartTimeScale;
    private float StartFixedDeltaTime;
  
    
    void Start()
    {
        StartTimeScale = Time.timeScale;
        StartFixedDeltaTime = Time.fixedDeltaTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))//başlatır
        {
            StartSlowMotion();
            Hareket.hiz = 25f;


        }
        else if (Input.GetKeyDown(KeyCode.R))//durdurur bunu aynı tuş ile yapmayı dene
        {
            StopSlowMotion();
            Hareket.hiz = 8f;
        }

       
    }

    public void StartSlowMotion()
    {
        Time.timeScale = TimeScale;
        Time.fixedDeltaTime = StartFixedDeltaTime * TimeScale;
    }

    public void StopSlowMotion()
    {
        Time.timeScale = StartTimeScale;
        Time.fixedDeltaTime = StartFixedDeltaTime;
    }
}
