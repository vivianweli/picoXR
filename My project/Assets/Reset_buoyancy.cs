using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_buoyancy : MonoBehaviour
{
   public GameObject egg1;
    public GameObject egg2;
   public GameObject egg3;

    public void reset_eggs(){
        egg1.transform.localPosition = new Vector3(-929, 78, 1138);
        egg2.transform.localPosition = new Vector3(-972, 78, 1138);
        egg3.transform.localPosition = new Vector3(-1, 78, 1138);

    }
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
