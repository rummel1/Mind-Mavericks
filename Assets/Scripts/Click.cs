using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Click : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private MaterialApplier _materialApplier;
    // Start is called before the first frame update

    private void Awake()
    {
        _materialApplier = GetComponent<MaterialApplier>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("eren");
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        
        Debug.Log("eren");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

internal class MaterialApplier
{
}
