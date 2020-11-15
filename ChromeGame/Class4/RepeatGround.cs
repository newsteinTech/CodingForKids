using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatGround : MonoBehaviour
{
    float width;
    Vector3 startPosition;
    BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        boxCollider = GetComponent<BoxCollider2D>();

        width = boxCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        // if ground has moved its width distance...then reposition to start
        // if distance travelled is > the width... then repeat
        float distanceTravelled = startPosition.x - transform.position.x;
        if (distanceTravelled > width)
        {
            transform.position = startPosition;
        }
         
    }
}
