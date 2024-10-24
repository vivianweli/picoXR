using UnityEngine;

public class buoyancy : MonoBehaviour
{
    public float buoyancyForce;
    public Transform waterSurface;
    public float buoyancyFactor;
    public float dragLiquid;

    // when egg touches the liquid
    void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // get the depth of the egg in the water with some buoyancy factor applied to tweak buoyancy result
            float objectDepth = waterSurface.position.y - rb.transform.position.y + buoyancyFactor;  
            Debug.Log(other + " "+ objectDepth);
            if (objectDepth > 0)  // Check if the object is submerged
            {
                // Apply buoyancy based on mass, buoyancyForce is different for different liquid
                float massFactor = Mathf.Clamp(1f / rb.mass, 0f, 1f);
                rb.AddForce(Vector3.up * buoyancyForce * massFactor);
                rb.drag = dragLiquid;  // Increase drag for liquid resistance
                
            }
            else{
                // reset the drag if egg is not submerged
                rb.drag = 0.1f;
                rb.angularDrag = 0.05f;

            }
            

        }
    }
}
