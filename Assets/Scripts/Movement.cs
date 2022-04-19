using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource rocketSound;
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    bool m_Play;
    bool m_ToggleChange;

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
                rocketSound.Play();  
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
