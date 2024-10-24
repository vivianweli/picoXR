using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pour : MonoBehaviour
{
    private ParticleSystem liquidParticles; // Reference to the Particle System
    public GameObject level; // vinegar level height

    private float currentTilt = 0f; // Current tilt angle
    private float targetTilt = 45f; // Target tilt angle
    private float duration = 2f;     // Duration of rotation
    public bool played = false;

   public void Pour(){
        // get the vinegar liquid particle system object and its emission rate as a variable
        liquidParticles = GetComponentInChildren<ParticleSystem>();
        var emission = liquidParticles.emission;

       // if the volcano reaction has not been played
        if (played == false )
        {
            // Start the experiment 
            StartCoroutine(MoveObjectWithDelay());
        } else {
            // no pouring effect
            emission.rateOverTime = 0;
        }
   } 


    // Start is called before the first frame update
    void Start()
    {
        // get the vinegar liquid particle system object
        liquidParticles = GetComponentInChildren<ParticleSystem>();


    }

    // Update is called once per frame, for debugging on the computer
    void Update()
    {
        // get the vinegar liquid particle system's emission rate as a variable
        var emission = liquidParticles.emission;
       // Check if the UpArrow key is pressed and if volcano experiment has not been played
        if (played == false && Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Start the experiment
            StartCoroutine(MoveObjectWithDelay());
        } else {
            // no pouring effect
            emission.rateOverTime = 0;
        }
    }

    // Move the vinegar and pour it
    IEnumerator MoveObjectWithDelay()
    {
        // get the vinegar liquid particle system's emission rate as a variable
        var emission = liquidParticles.emission;
        // Move to the first position
        transform.localPosition = new Vector3(-436, 109, 399);

        // Wait for 1 second
        yield return new WaitForSeconds(1);

        // initialize an elapsed time 
        float elapsed = 0f;
        // Get the vinegar level's y current scale
        Vector3 scale = level.transform.localScale; 

        // do it incrementally
        while (elapsed < duration)
        {   
            // start the pouring particle effect
            emission.rateOverTime = 100;
            // Calculate the percentage of completion
            float t = elapsed / duration;

            // Interpolate the angle of tilt forward
            float angle = Mathf.Lerp(currentTilt, targetTilt, t);

            // Apply the rotation
            transform.localRotation = Quaternion.Euler(0f, 0f, angle);

            // Increment elapsed time
            elapsed += Time.deltaTime;

            // if there is vinegar level height
            if (scale.y >= 0){
                // decrease it by 0.05
                scale.y -= 0.05f; 
                // apply that to the vinegar level object
                level.transform.localScale = scale;    

                // Adjust the position of the vinegar level to make it appear fixed at the bottom
                Vector3 newPos = level.transform.localPosition;
                newPos.y -= 0.05f; // Adjust position downwards
                // apply it to the object
                level.transform.localPosition = newPos;
                
            }

            // Wait for the next frame
            yield return null;
        }
        // reset elapsed time
        elapsed = 0f;

        // do it incrementally
        while (elapsed < duration)
        {
            // stop pouring effect
            emission.rateOverTime = 0;
            // Calculate the percentage of completion
            float t = elapsed / duration;

            // Interpolate the angle of tilt back
            float angle = Mathf.Lerp(targetTilt, currentTilt, t);

            // Apply the rotation
            transform.localRotation = Quaternion.Euler(0f, 0f, angle);

            // Increment elapsed time
            elapsed += Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }
        

        
        // Wait for a second before rotating back
        yield return new WaitForSeconds(1);
    
            
        // Move back to the position on the table after the delay
        transform.localPosition = new Vector3(-408, 80, 360);
        // indicate the experiment has been conducted by toggling the flag
        played = true;
}

    
}
