using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab;
    //set up time in between bubble spawns
    public float spawnTimer = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnBubble());
    }

    //start coroutine
    IEnumerator spawnBubble()
    {
        while (true)
        {
            //create minimum and maximum xy values for random spawn positions
            Vector2 spawnX = new Vector2(-8, 8);
            Vector2 spawnY = new Vector2(-6, 0);

            //create a random xy coordinate to spawn on
            float randomX = Random.Range(spawnX.x, spawnX.y);
            float randomY = Random.Range(spawnY.x, spawnY.y);
            Vector2 randomPosition = new Vector2(randomX, randomY);

            //spawn bubbles
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
                //instantiate a copy of the prefab at generated random position
                GameObject newBubble = Instantiate(bubblePrefab, randomPosition, Quaternion.identity);
                
                //reset timer back to default to keep spawning bubbles at the same time interval
                spawnTimer = 0.3f;
            }
            yield return null;
        }
    }
}