using UnityEngine;

public class buoyancy : MonoBehaviour
{
    public float buoyancyForce = 10f;
    public Transform waterSurface;
    public float buoyancyFactor;

    void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null)
        {
            float objectDepth = waterSurface.position.y - rb.transform.position.y + buoyancyFactor;  // Depth of the object in the water
            Debug.Log(other + " "+ objectDepth);
            if (objectDepth > 0)  // Check if the object is submerged
            {
                // Apply buoyancy based on mass (denser objects will sink)
                float massFactor = Mathf.Clamp(1f / rb.mass, 0f, 1f);
                rb.AddForce(Vector3.up * buoyancyForce * massFactor);
                rb.drag = 3f;  // Increase drag for liquid resistance
                
            }
            else{
                rb.drag = 0.1f;
                rb.angularDrag = 0.05f;

            }
            

        }
    }
}
