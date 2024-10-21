using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)){
            anim.SetTrigger("Left");

        }
         
    }

    // Update is called once per frame
    // void OnTriggerExit(Collider other)
    // {
    //     anim.SetTrigger("Click");
    // }
}
