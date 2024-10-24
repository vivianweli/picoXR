using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class catch_particles : MonoBehaviour
{
    public ParticleSystem particleEruption;
    public GameObject baking_soda;
    public AudioSource myAudioSource;

    
    // Called when the particles of vinegar collides with the volcano
    void OnParticleCollision(GameObject other)
    {
        // play the sound effect
        myAudioSource.Play();
        // start the particle eruption
        particleEruption.Play();
        // hide the baking soda powder
        baking_soda.SetActive(false);
        

    
        
        
    
    }

}

