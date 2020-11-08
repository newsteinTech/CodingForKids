using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool isOnGround;
    Rigidbody2D rb;
    AudioSource audioSource;
 
    public float jumpForce = 10;
    public AudioClip jumpAudioClip;
    public AudioClip gameOverClip;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for isOnGround condition as well pressed Spacebar...then jump.
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true) 
        {
            Jump();
        }

    }



    void Jump()
    {
        // Apply force
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        // Play jump audio
        audioSource.PlayOneShot(jumpAudioClip);

        // set isOnGround to false
        isOnGround = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Ground")
        {
            // set isOnGround to true
            isOnGround = true;
        } else
        {
            // Game over
            audioSource.PlayOneShot(gameOverClip);

            Debug.Log("Game over");
            Time.timeScale = 0;
        }
    }

}
