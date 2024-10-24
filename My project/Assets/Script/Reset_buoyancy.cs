using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_buoyancy : MonoBehaviour
{
   public GameObject egg1;
    public GameObject egg2;
   public GameObject egg3;

    public void reset_eggs(){
        // reset the positions of all the eggs
        egg1.transform.localPosition = new Vector3(-929, 78, 1138);
        egg2.transform.localPosition = new Vector3(-972, 78, 1138);
        egg3.transform.localPosition = new Vector3(-1015, 78, 1138);
        // reset the rotation of eggs
        egg1.transform.localRotation = Quaternion.Euler(0,0,0);
        egg2.transform.localRotation = Quaternion.Euler(0,0,0);;
        egg3.transform.localRotation = Quaternion.Euler(0,0,0);;
        // reset the drag of the eggs for air
        egg1.GetComponent<Rigidbody>().drag = 0.1f;
        egg2.GetComponent<Rigidbody>().drag = 0.1f;
        egg3.GetComponent<Rigidbody>().drag = 0.1f;

        // reset the velocities of the eggs
        egg1.GetComponent<Rigidbody>().velocity = Vector3.zero;
        egg2.GetComponent<Rigidbody>().velocity = Vector3.zero;
        egg3.GetComponent<Rigidbody>().velocity = Vector3.zero;
        egg1.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        egg2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        egg3.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        

    }
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame, for debugging on the computer
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
             // reset the positions of all the eggs
            egg1.transform.localPosition = new Vector3(-929, 78, 1138);
            egg2.transform.localPosition = new Vector3(-972, 78, 1138);
            egg3.transform.localPosition = new Vector3(-1015, 78, 1138);
            // reset the rotation of eggs
            egg1.transform.localRotation = Quaternion.Euler(0,0,0);;
            egg2.transform.localRotation = Quaternion.Euler(0,0,0);;
            egg3.transform.localRotation = Quaternion.Euler(0,0,0);;

            // reset the drag of the eggs for air
            egg1.GetComponent<Rigidbody>().drag = 0.1f;
            egg2.GetComponent<Rigidbody>().drag = 0.1f;
            egg3.GetComponent<Rigidbody>().drag = 0.1f;
            // reset the velocities of the eggs
            egg1.GetComponent<Rigidbody>().velocity = Vector3.zero;
            egg2.GetComponent<Rigidbody>().velocity = Vector3.zero;
            egg3.GetComponent<Rigidbody>().velocity = Vector3.zero;
            egg1.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            egg2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            egg3.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}
