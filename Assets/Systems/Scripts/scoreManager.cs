using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class scoreManager : MonoBehaviour
{
    //set initial clicks to 0
    public int baseScore = 0;

    //clicks so far in any given timeframe
    public int clickCounter = 0;

    //check
    public float clickTimer = 0f;
    
    //timeframe given before checking for how many clicks
    public float checkClicksPerSecond = 1f;

    void Update()
    {
        //check if 1 second has passed
        clickTimer += Time.deltaTime;

        if (clickTimer >= checkClicksPerSecond)
        {
            //calculate clicks per second by dividing how many clicks the player has made in the past 1 second
            float clicksPerSecond = clickCounter / clickTimer;

            if (clicksPerSecond >= 3)
            {
                StartCoroutine(feverMode());
            }

            else
            {
                StopCoroutine(feverMode());
            }

            //reset cps check
            clickTimer = 0f;
            clickCounter = 0;
        }

        //check if mouse is clicked
        if (Input.GetMouseButtonDown(0))
        {
            clickCounter++;
            baseScore++;
        }

        //use getcomponent to get the text component from the attached gameobject
        TextMeshProUGUI scoreText = GetComponent<TextMeshProUGUI>();

        //display total bubbles spawned as text
        scoreText.text = "Score:" + baseScore;
    }

    IEnumerator feverMode()
    {
        Debug.Log("fever mode active");
        if (Input.GetMouseButtonDown(0))
        {
            scoreIncrement = 10;
            baseScore = baseScore + scoreIncrement;
        }
        yield return null;
    }
}
