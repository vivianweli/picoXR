using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_reset : MonoBehaviour
{
    public PlantGrowt plantgrowth;

    public void resetPlant(){//reset the plant growth
        plantgrowth.Reset();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)){
           plantgrowth.Reset();

        }
    }
}
