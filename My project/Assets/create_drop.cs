using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_drop : MonoBehaviour
{
    public GameObject liquidParticlePrefab; // Reference to the liquid particle prefab
    public ParticleSystem particleSystem; // Reference to the particle system
    public float spawnRate = 10f; // How many particles to emit per second

    private void Start()
    {
        if (particleSystem == null)
        {
            particleSystem = GetComponent<ParticleSystem>();
        }

        // Start coroutine to convert particles
        StartCoroutine(ConvertParticles());
    }

    private IEnumerator ConvertParticles()
{
    while (true)
    {
        if (particleSystem.isPlaying)
        {
            // Get the current particles from the Particle System
            ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleSystem.particleCount];
            int particleCount = particleSystem.GetParticles(particles);

            for (int i = 0; i < particleCount; i++)
            {
                // Only instantiate if the particle is about to die
                if (particles[i].remainingLifetime <= Time.deltaTime)
                {
                    // Get the position of the particle in world space
                    Vector3 position = particles[i].position; 
                     Vector3 worldPosition = transform.TransformPoint(position);
                    Instantiate(liquidParticlePrefab, worldPosition, Quaternion.identity);
                }
            }
        }

        yield return new WaitForSeconds(1f / spawnRate);
    }
}

}

