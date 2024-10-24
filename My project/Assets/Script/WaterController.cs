using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WaterController : MonoBehaviour
{
    public PlantGrowt plantGrowth; // pant growth code
    public GameObject targetObject; // bottle
    public bool isWaterOn = false; // set water status is false
    private Animator targetAnimator; // watering animation
    public LightController lightController;

    // Start is called before the first frame update
    void Start()
    {
        // initialize the plant's water status
        if (plantGrowth != null)
        {
            plantGrowth.SetWaterStatus(isWaterOn); // set the water status in plantgrowth code
        }
        else
        {
            Debug.LogError("no plant in the inspector");
        }
        //get bottle's animation
        if (targetObject != null)
        {
            targetAnimator = targetObject.GetComponent<Animator>();
            //Debug.Log("Animator successfully retrieved: " + targetAnimator);
            if (targetAnimator == null)
            {
                Debug.LogError("no animation in bottle");
            }
        }
        else
        {
            Debug.LogError("no bottle");
        }
    
    }
    // water the plant
    public void WaterPouring()
    {
            Debug.LogError("click the bottle");

            if (targetAnimator != null)
            {
                targetAnimator.Play("Rotation-Bottle", 0, 0f);  // animation play
            }

            isWaterOn = true;
            plantGrowth.SetWaterStatus(isWaterOn);

            // plant growth
            if (isWaterOn && lightController.isLightOn)
            {
                plantGrowth.GrowPlant();
            }
    }
    // Update is called once per frame
    void Update()
    {
        // mouse event
        if (Input.GetMouseButtonDown(0))
        {
           Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           RaycastHit hit;
           //Debug.LogError("clicked");
           //Debug.LogError("ray start position: " + ray.origin + ", ray direcion: " + ray.direction);

           if (Physics.Raycast(ray, out hit))
           {
               if (hit.collider.gameObject == targetObject)
               {
                   //Debug.LogError("click the object：" + hit.collider.gameObject.name);
                   Debug.LogError("click the bottle");
                   if (targetAnimator != null)
                   {
                       // animation plays when the mouse clicks
                       //targetAnimator.ResetTrigger("StartAnimation");
                       //targetAnimator.SetTrigger("StartAnimation")
                       targetAnimator.Play("Rotation-Bottle", 0, 0f); 
                   }

                   isWaterOn = true;
                   plantGrowth.SetWaterStatus(isWaterOn);
                   // if water is on and light is on, plant growth
                   if (isWaterOn && lightController.isLightOn)
                   {
                       plantGrowth.GrowPlant();
                   }

                   //Debug.Log("water is on, plant grows");
               }
           }
        }

        //check if the animation has ended
        if (targetAnimator != null)
        {
            AnimatorStateInfo stateInfo = targetAnimator.GetCurrentAnimatorStateInfo(0);
            //Debug.Log("current the animation status name: " + stateInfo.IsName("Rotation-Bottle"));
            //Debug.Log("current normalizedTime: " + stateInfo.normalizedTime);

            if (stateInfo.IsName("Rotation-Bottle") && stateInfo.normalizedTime >= 1.0f)
            {
                isWaterOn = false;
                plantGrowth.SetWaterStatus(isWaterOn); // reset the plant's water status
            }
        }
    }
}
