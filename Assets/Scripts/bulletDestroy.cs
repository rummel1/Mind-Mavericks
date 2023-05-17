using System.Collections;
using UnityEngine;

public class bulletDestroy : MonoBehaviour
{
    public float timeToDestroy;
    
    void Start()
    {
        StartCoroutine(DestroyObject());
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
    
}