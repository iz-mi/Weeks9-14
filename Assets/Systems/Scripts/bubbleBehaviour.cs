using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bubbleBehaviour : MonoBehaviour
{
    //set up timer to destroy instantiated object
    public float destroyInstantiation = 5f;

    //set up bubble movement speed
    float speed = 3;

    // Update is called once per frame
    void Update()
    {
        //make bubbles float upward
        Vector2 position = transform.position;
        position.y += speed * Time.deltaTime;
        transform.position = position;

        //destroy instantiation timer, reduces counter each frame, destroys instantiated gameObject once it reaches 0
        destroyInstantiation -= Time.deltaTime;
        if (destroyInstantiation <= 0)
        {
            Destroy(gameObject);
        }
    }



}
