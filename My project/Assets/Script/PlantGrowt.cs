using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantGrowt : MonoBehaviour
{
    public Light plantLight;
    public bool isWaterOn;
    public int currentStage = 0; //current plant growth stage
    public GameObject stemObject;  // stem
    public GameObject leafObject1;  // leaf1
    public GameObject leafObject2;  // leaf2
    public bool isStemVisible = false;  // stem visible or not
    public bool isLeaf1Visible = false;  // leaf1 visible or not
    public bool isLeaf2Visible = false;  // leaf2 visible or not
    public TextMeshPro countdownText;  // timer text
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GrowPlant()
    {
        if (currentStage == 0)// first stage--stem show out
        {
            Debug.Log("111");
            currentStage++;
            //ToggleStem();
            StartCoroutine(ToggleStemWithCountdown());
        }
        else if (currentStage == 1)//second stage--leaf1 show out
        {
            Debug.Log("222");
            currentStage++;
            //ToggleLeaf1();
            StartCoroutine(ToggleLeaf1WithCountdown());
        }
        else if(currentStage == 2)//third stage--leaf2 show out
        {
            Debug.Log("333");
            currentStage++;
            //ToggleLeaf2();
            StartCoroutine(ToggleLeaf2WithCountdown());
        }
        else
        {
            Debug.Log("cannot water the plant!");
        }
    }
    // coroutine to implement a countdown and toggle the display state of the stem
    IEnumerator ToggleStemWithCountdown()
    {
        yield return StartCoroutine(StartCountdown()); // countdown
        ToggleStem();  // toggle the visibility of the stem
    }

    IEnumerator ToggleLeaf1WithCountdown()
    {
        yield return StartCoroutine(StartCountdown()); // countdown
        ToggleLeaf1();  // toggle the visibility of the leaf1
    }

    IEnumerator ToggleLeaf2WithCountdown()
    {
        yield return StartCoroutine(StartCountdown()); // countdown
        ToggleLeaf2();  // toggle the visibility of the leaf2
    }
    // countdown
    IEnumerator StartCountdown()
    {
        countdownText.faceColor = new Color32(255, 0, 0, 255);
        int countdownTime = 3;
        while (countdownTime > 0)
        {
            Debug.Log(countdownTime); // show the time
            countdownText.text = "Timer: " + countdownTime.ToString(); // show the timertext
            yield return new WaitForSeconds(1); // wait for 1s
            countdownTime--;
        }
        countdownText.text = "PLANT GROWTH!!!"; // display at the end of the countdown
        yield return new WaitForSeconds(1); // display for 1s and then clear
        countdownText.text = ""; // clear the text
        Debug.Log("PLANT GROWTH!!!"); 
    }

    // set water status
    public void SetWaterStatus(bool isWater)
    {
        isWaterOn = isWater;
        if (isWaterOn)
        {
            Debug.Log("plant receives water and prepares to grow");
        }
        else
        {
            Debug.Log("plant stops growing due to lack of water");
        }
    }

    // toggle the visibility of stem 
    void ToggleStem()
    {
        if (stemObject != null)
        {
            isStemVisible = !isStemVisible;  
            stemObject.SetActive(isStemVisible);
        }
    }

    // toggle the visibility of leaf1
    void ToggleLeaf1()
    {
        if (leafObject1 != null)
        {
            isLeaf1Visible = !isLeaf1Visible;  
            leafObject1.SetActive(isLeaf1Visible);
        }
    }
    void ToggleLeaf2()
    {
        if (leafObject2 != null)
        {
            isLeaf2Visible = !isLeaf2Visible;  
            leafObject2.SetActive(isLeaf2Visible);
        }
    }
    public void Reset(){
        // reset all flags and stage of growth
        currentStage = 0;
        isStemVisible = false;
        isLeaf1Visible = false;
        isLeaf2Visible = false;
        // hide leaf and stem
        stemObject.SetActive(isStemVisible);
        leafObject1.SetActive(isLeaf1Visible);
        leafObject2.SetActive(isLeaf2Visible);
    }
}