using UnityEngine;
public class atobmover : MonoBehaviour
{
    public Vector3 pointA, pointB;
    public float speed = 2.0f;
    private Vector3 currentTarget;

    void Start()
    {
        currentTarget = pointB;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

        if (transform.position == pointB)
            currentTarget = pointA;
        else if (transform.position == pointA)
            currentTarget = pointB;
    }
}

