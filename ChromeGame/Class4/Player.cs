using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    bool isOnGround;
    Rigidbody2D rb;
    AudioSource audioSource;
 
    public float jumpForce = 10;
    public AudioClip jumpAudioClip;
    public AudioClip gameOverClip;

    public GameObject restartButton;

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
        if (Input.GetMouseButtonDown(0) && isOnGround == true) 
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
            GameOver();
        }
    }


    void GameOver()
    {
        // Game over
        audioSource.PlayOneShot(gameOverClip);
        restartButton.SetActive(true);

        Debug.Log("Game over");
        Time.timeScale = 0;
    }


    public void RestartGame()
    {
        Time.timeScale = 1;
        restartButton.SetActive(false);

        SceneManager.LoadScene(0);  
    }

}
