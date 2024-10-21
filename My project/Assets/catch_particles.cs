using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class catch_particles : MonoBehaviour
{
    public ParticleSystem particleEruption;
    public GameObject baking_soda;
    public AudioSource myAudioSource;

    
    // Called when a particle collides with this GameObject
    void OnParticleCollision(GameObject other)
    {
        
        myAudioSource.Play();
        particleEruption.Play();
        Destroy(baking_soda);
        

    
        
        
    
    }

}

