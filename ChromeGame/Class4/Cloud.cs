using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{ 
    Vector3 startPosition;

    public float minXValue = -20;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < minXValue)
        {
            transform.position = startPosition;
        }
    }
}
