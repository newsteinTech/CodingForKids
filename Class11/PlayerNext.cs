using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNext : MonoBehaviour
{
    public float jumpForce = 10f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
