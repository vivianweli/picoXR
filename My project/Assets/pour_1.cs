using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pour_1 : MonoBehaviour
{
    public float maxTiltAngle = 45f;   // Maximum tilt angle (degrees)

    private float currentTiltX = 0f;   // Current tilt on the x-axis
    private ParticleSystem liquidParticles; // Reference to the Particle System
    public GameObject oil_level; 
    


    // Start is called before the first frame update
    void Start()
    {
        liquidParticles = GetComponentInChildren<ParticleSystem>();


    }

    // Update is called once per frame
    void Update()
    {
        var emission = liquidParticles.emission;
       // Check if the UpArrow key is pressed (or any other key you want to use)
        if (Input.GetKey(KeyCode.DownArrow))
        {
            // Tilt forward (increase the tilt on the x-axis)
            currentTiltX += 1f;
            emission.rateOverTime = 100;
            Vector3 scale = oil_level.transform.localScale; // Get the current scale
            

            if (scale.y >= 0){
                scale.y -= 0.01f; // Set the Y component to 2
                oil_level.transform.localScale = scale;    

                // Adjust the position to keep the bottom fixed
                Vector3 newPos = oil_level.transform.localPosition;
                newPos.y -= 0.01f; // Adjust position downwards
                oil_level.transform.localPosition = newPos;
                
            }
            
            
        }
        else
        {
            // Slowly return to the original position when the key is released
            currentTiltX = Mathf.Lerp(currentTiltX, 0f, Time.deltaTime * 2f);
            emission.rateOverTime = 0;
        }

        // Clamp the tilt angle to prevent over-tilting
        currentTiltX = Mathf.Clamp(currentTiltX, 0f, maxTiltAngle);

        // Apply the tilt to the cup (rotate around the x-axis)
        transform.localRotation = Quaternion.Euler(currentTiltX, 0f, 0f );

        
    } 
    
}
