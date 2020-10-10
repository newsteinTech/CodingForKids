using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarNitro : MonoBehaviour
{
    bool isNitroActive;
    float nitroTimer;

    Rigidbody rb;
    AudioSource audioSource;

    public float nitroTime = 2.0f;
    public float nitroForce = 10f;

    public AudioClip nitroAudioClip;
    public GameObject nitroEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // If nitro is active
        if (isNitroActive == true)
        {
            if (nitroTimer > this.nitroTime)
            {
                isNitroActive = false;
                nitroTimer = 0;

                nitroEffect.SetActive(false);
            }

            nitroTimer += Time.deltaTime;
            ApplyNitro();
            return;
        }

        // If nitro is not active, check for key press;
        if (Input.GetKeyDown(KeyCode.N))
        {
            isNitroActive = true;
            ApplyNitro();
            nitroEffect.SetActive(true);
        }

    }

    public void ApplyNitro()
    {
        // Add force
        rb.AddForce(transform.forward * nitroForce, ForceMode.Acceleration);

        // play nitro sound
        audioSource.pitch = 1;
        audioSource.PlayOneShot(nitroAudioClip);
    }

}
