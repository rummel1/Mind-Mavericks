using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private ConstantForce _force;

    private Vector3 _ForceDirection;
    // Start is called before the first frame update
    void Start()
    {
        _force = GetComponent<ConstantForce>();
        _ForceDirection = new Vector3(0, -1, 0);
        _force.force = _ForceDirection;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            _ForceDirection *= -1;
            _force.force = _ForceDirection;
        }
    }
}
