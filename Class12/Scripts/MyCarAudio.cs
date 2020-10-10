using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCarAudio : MonoBehaviour
{
    AudioSource audioSource;
    SimpleCarController carController;

    public float smoothSpeed = 0.125f;
    public AudioClip accelerationAudioClip;
    public AudioClip deAccelerationAudioClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        carController = GetComponent<SimpleCarController>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(carController.velocity, 0f))
        {
            audioSource.pitch = 0;
            return;
        }

        float pitch = carController.velocity / 10;

        pitch = Mathf.Clamp(pitch, 0, 2);

        audioSource.pitch = pitch;
        //audioSource.pitch = Mathf.Lerp(audioSource.pitch, pitch, smoothSpeed);

        if (carController.acceleration > 0)
        {
            audioSource.PlayOneShot(accelerationAudioClip);
        } else
        {
            audioSource.PlayOneShot(deAccelerationAudioClip);
        }
    }
}
