using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light plantLight; // spotligth in the scene
    public bool isLightOn = false;
    public GameObject targetObject; // lamp base
    public float lightDuration = 15f; // keep light on for 15s, then automatic light off
    public PlantGrowt plantGrowth; // call the plant growth code
    public WaterController waterController; // call the water code

    public void LightControl(){
        if (plantLight != null)
        {
            plantLight.enabled = isLightOn; // make sure the light is off at the beginning
        }
        else
        {
            Debug.LogError("no light in the inspector");
        }
        isLightOn = !isLightOn;
        plantLight.enabled = isLightOn;
        // if light is on, start the auto shut-off coroutine
        if (isLightOn)
        {
            StartCoroutine(AutoTurnOffLight());
            if (waterController.isWaterOn)
            {
                plantGrowth.GrowPlant(); // plant growth
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (plantLight != null)
        {
            plantLight.enabled = isLightOn; 
        }
        else
        {
            Debug.LogError("no light in the inspector");
        }

        
    }

    // Update is called once per frame
    public void Update()
    {
        //Debug.LogError("start");
        // mouse event
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.LogError("clicked");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // ray test
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Default")))
            {
                //Debug.LogError("clicked object:" + hit.collider.gameObject.name);
                if (hit.collider.gameObject == targetObject)
                {
                    Debug.LogError("clicked！！isLightOn is:" + isLightOn);
                    //Debug.LogError("ray start place: " + ray.origin + ", ray direction: " + ray.direction);
                    // change the state of light
                    isLightOn = !isLightOn;
                    plantLight.enabled = isLightOn;
                    if (isLightOn)
                    {
                        StartCoroutine(AutoTurnOffLight());
                        if (waterController.isWaterOn)
                        {
                            plantGrowth.GrowPlant(); 
                        }
                    }

                }
            }
        }
    }
    // auto shut-off coroutine
    private IEnumerator AutoTurnOffLight()
    {
        yield return new WaitForSeconds(lightDuration); // wait for the setting time
        SetLight(false); // turn off light
    }
    // set light on/off
    public void SetLight(bool isOn)
    {
        isLightOn = isOn;
        plantLight.enabled = isLightOn;
    }
}