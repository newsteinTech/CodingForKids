using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public float minXValue = -15;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < minXValue)
        {
            // Destroy
            Destroy(gameObject);
        }
    }
}
