using UnityEngine;

public class fanturn : MonoBehaviour
{
    public float rotationSpeed = 10f; // Dönme hızı

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, 0f, 0f, Space.World);
    }
}