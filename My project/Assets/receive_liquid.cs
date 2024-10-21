using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class receive_liquid : MonoBehaviour
{
    private ParticleSystem caughtParticles; // Reference to the Particle System for caught liquid

    void Start()
    {
        // Create a new Particle System to represent the caught liquid
        caughtParticles = gameObject.AddComponent<ParticleSystem>();
        var main = caughtParticles.main;
        main.startColor = new ParticleSystem.MinMaxGradient(Color.blue); // Set the color to represent liquid
        main.startSize = 0.2f; // Adjust the size as necessary
        caughtParticles.Stop(); // Stop it initially
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Caught particles from: " + other.name); // Log what triggered the event
        // You can customize this logic based on how you want to visualize the caught liquid
        caughtParticles.Play(); // Start emitting particles for caught liquid
    }

    private void OnParticleTrigger()
    {
        // This can be used to handle additional logic when particles enter the trigger area if needed
    }
}
