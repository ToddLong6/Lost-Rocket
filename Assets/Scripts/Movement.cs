using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // PARAMETERS - for tuning, typically a set in the editor
    // CACHE - e.g. references for readability or speed
    // STATE - private instance (member) variables
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;
    Rigidbody rb;
    AudioSource rocketSound;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rocketSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!rocketSound.isPlaying)
            {
                rocketSound.PlayOneShot(mainEngine);  
            }
        }
        else
            {
                rocketSound.Stop();
            }
    }    
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }
    }
    void ApplyRotation(float rotationTHisFrame)
    {
        rb.freezeRotation = true; //freezing rotation
        transform.Rotate(Vector3.forward * rotationTHisFrame * Time.deltaTime);
        rb.freezeRotation = true; //unfreezing rotation
    }
}
