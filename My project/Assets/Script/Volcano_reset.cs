using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volcano_reset : MonoBehaviour
{
    public pour vinegar; 
    public catch_particles volcano;
    public void volcanoReset(){
        // reset played flag
        vinegar.played = false;
        // stop audio
        volcano.myAudioSource.Stop();
        // stop and clear the eruption particle system
        volcano.particleEruption.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        // baking soda reappears
        volcano.baking_soda.SetActive(true);
        // reset the vinegar volume
        vinegar.level.transform.localScale = new Vector3(12,5,12);
        vinegar.level.transform.localPosition = new Vector3(-0.9f,-0.6f,-0.3f);
    }
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame, for debugging on the computer
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            // reset played flag
            vinegar.played = false;
            // stop audio
            volcano.myAudioSource.Stop();
            // stop and clear the eruption particle system
            volcano.particleEruption.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            // baking soda reappears
            volcano.baking_soda.SetActive(true);
            // reset the vinegar volume
            vinegar.level.transform.localScale = new Vector3(12,5,12);
            vinegar.level.transform.localPosition = new Vector3(-0.9f,-0.6f,-0.3f);

        }
        
    }
}
